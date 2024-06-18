using Store.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Vendas.Application.Commands
{
    public class CancelarProcessamentoPedidoEstornarEstoqueCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public CancelarProcessamentoPedidoEstornarEstoqueCommand(Guid pedidoId, Guid clienteId)
        {
            AggregateID = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}
