using FluentValidation;
using Store.Core.Messages;

namespace Store.Vendas.Application.Commands
{
    public class AddItemPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public AddItemPedidoCommand (Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;  
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddItemPedidoValidation : AbstractValidator<AddItemPedidoCommand> 
    {
        public AddItemPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto não foi informado");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade miníma de um item é 1");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade máxima de um item é 15");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("O valor do item precisa ser maior que 0");
        }
    }
}
