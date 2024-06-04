using MediatR;
using Store.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AddItemPedidoCommand, bool>
    {
        public async Task<bool> Handle(AddItemPedidoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;
            throw new NotImplementedException();
        }

        private bool ValidarComando(Command message)
        {
            if (message.IsValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                // lançar um evento de erro
            }

            return false;
        }
    }
}
