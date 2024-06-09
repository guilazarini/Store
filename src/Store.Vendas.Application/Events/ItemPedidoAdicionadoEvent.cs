using Store.Core.Messages;

namespace Store.Vendas.Application.Events
{
    public class ItemPedidoAdicionadoEvent : Event
    {
        public Guid ClienteID { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }

        public ItemPedidoAdicionadoEvent(Guid clienteId, Guid pedidoId, Guid produtoId, decimal valorUnitario, int quantidade)
        {
            AggregateID = pedidoId;
            ClienteID = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }
    }
}
