using MediatR;
using Store.Catalogo.Domain.Interfaces;
using Store.Core.Communication.Mediator;
using Store.Core.Messages.IntagrationEvents;
using Store.Vendas.Application.Events;

namespace Store.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>,
        INotificationHandler<PedidoProcessamentoCanceladoEvent>
                                        
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetById(notification.AggregateID);

        }

        public async Task Handle(PedidoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(notification.ProdutosPedidos);

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(notification.PedidoID, notification.ClienteId, notification.Total, notification.ListaProdutosPedido, notification.NomeCartao, notification.NumeroCartao,notification.ExpiracaoCartao, notification.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(notification.PedidoID, notification.ClienteId));
            }
        }

        public async Task Handle(PedidoProcessamentoCanceladoEvent notification, CancellationToken cancellationToken)
        {
            await _estoqueService.ReporListaProdutosPedido(notification.ProdutosPedido);
        }
    }
}
