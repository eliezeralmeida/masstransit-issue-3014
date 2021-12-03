using System;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;

namespace SendApplication.Filters
{
    public class SendHeaderFilter<T> : IFilter<SendContext<T>> where T : class
    {
        public async Task Send(SendContext<T> context, IPipe<SendContext<T>> next)
        {
            context.Headers.Set("Some-Header", "some-value");
            Console.ForegroundColor = ConsoleColor.Blue;
            await Console.Out.WriteLineAsync("Some header addede");

            await next.Send(context);
        }

        public void Probe(ProbeContext context)
        {
        }
    }
}