using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace SendApplication.Controllers
{
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly IRequestClient<SomeRequest> _client;

        public SendController(IRequestClient<SomeRequest> client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Send()
        {
            var response2 = await _client.GetResponse<SomeResponse>(new SomeRequest("payload"));

            return Ok($"Message response {response2.Message}");
        }
    }
}