using Store.Core.Messages.CommonMessages.DomainEvents;

namespace Store.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int Quantidaderestante {  get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidaderestante) : base(aggregateId)
        {
            Quantidaderestante = quantidaderestante;
        }
    }
}
