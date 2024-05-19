using Store.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
