using Store.Core.Messages;

namespace Store.Vendas.Application.Events
{
    public class PedidoAtualizadoEvent : Event
    {
        public Guid ClienteID { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal ValorTotal { get; private set; }

        public PedidoAtualizadoEvent(Guid clienteId, Guid pedidoId, decimal valorTotal)
        {
            AggregateID = pedidoId;
            ClienteID = clienteId;
            PedidoId = pedidoId;
            ValorTotal = valorTotal;
        }
    }
}
