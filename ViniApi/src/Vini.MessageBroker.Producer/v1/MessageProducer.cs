using Confluent.Kafka;
using Vini.MessageBroker.Producer.v1.Message;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Vini.MessageBroker.Producer.v1
{
    public class MessageProducer : IMessageProducer
    {
        private readonly ILogger<MessageProducer> _log;

        public MessageProducer(ILogger<MessageProducer> log)
        {
            _log = log;
        }

        public async Task SendMessageAsync<T>(string topicName, Message<T> message) where T : class
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                _log.LogInformation($"[{nameof(MessageProducer)}][{nameof(SendMessageAsync)}]Posted|{JsonSerializer.Serialize(message)}");

                var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = JsonSerializer.Serialize(message) });
            }
        }
    }
}
