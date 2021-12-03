using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SendApplication.Models;

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
            try
            {
                var response = await _client.GetResponse<SomeResponse>(new());
            }
            catch (Exception e)
            {
                // ignore error because no receiver implemented
            }

            return Ok();
        }
    }
}