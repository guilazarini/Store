using Store.Core.Messages;

namespace Store.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateID = aggregateId;
        }
    }
}
