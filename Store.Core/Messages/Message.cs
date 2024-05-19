namespace Store.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }

        public Guid AggregateID { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
