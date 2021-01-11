using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace EquinoxMessageBroker.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = "localhost:9092",
                    GroupId = $"topic-mac-group-0",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };
                CancellationTokenSource cts = new CancellationTokenSource();
                
                try
                {
                    using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                    {
                        consumer.Subscribe("topic-mac");

                        try
                        {
                            while (true)
                            {
                                var cr = consumer.Consume(cts.Token);
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            consumer.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
