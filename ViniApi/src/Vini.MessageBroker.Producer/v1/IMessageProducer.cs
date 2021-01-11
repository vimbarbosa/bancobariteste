using Vini.MessageBroker.Producer.v1.Message;
using System.Threading.Tasks;

namespace Vini.MessageBroker.Producer.v1
{
    public interface IMessageProducer
    {
        Task SendMessageAsync<T>(string queueName, Message<T> message) where T : class;
    }
}
