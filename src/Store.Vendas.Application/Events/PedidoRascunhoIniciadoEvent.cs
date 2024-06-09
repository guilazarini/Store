using Store.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event    
    {
        public Guid ClienteID { get; private set; }
        public Guid PedidoId { get; private set; }

        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid pedidoId)
        {
            AggregateID = pedidoId;
            ClienteID = clienteId;
            PedidoId = pedidoId;
        }
    }
}
