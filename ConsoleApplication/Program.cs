using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace ConsoleApplication
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("some-request", x => x.Consumer<SomeRequestConsumer>());

                cfg.Host("localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await busControl.StartAsync(source.Token);

            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(Console.ReadLine, source.Token);
            }
            finally
            {
                await busControl.StopAsync(source.Token);
            }
        }
    }
}