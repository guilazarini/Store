using MediatR;
using FluentValidation.Results;


namespace Store.Core.Messages
{
    public  class Command : Message, IRequest<bool>
    {
        public DateTime TimeStamp { get; set; }

        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimeStamp = DateTime.UtcNow;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
