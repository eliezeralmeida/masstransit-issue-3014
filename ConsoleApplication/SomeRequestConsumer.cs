using System;
using System.Threading.Tasks;
using MassTransit;
using Shared.Models;

namespace ConsoleApplication
{
    public class SomeRequestConsumer : IConsumer<SomeRequest>
    {
        public async Task Consume(ConsumeContext<SomeRequest> context)
        {
            Console.WriteLine(context.Message);
            await context.RespondAsync(new SomeResponse("Response payload"));
        }
    }
}