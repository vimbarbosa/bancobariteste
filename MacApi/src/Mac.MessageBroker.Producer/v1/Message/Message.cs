using System;

namespace Mac.MessageBroker.Producer.v1.Message
{
    public abstract class Message<T> where T : class
    {
        public Guid ServiceId { get; set; }
        public T Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid RequestId { get; set; }

        protected Message(Guid serviceId, T content)
        {
            ServiceId = serviceId;
            Content = content;
            Timestamp = DateTime.Now;
            RequestId = Guid.NewGuid();
        }
    }
}
