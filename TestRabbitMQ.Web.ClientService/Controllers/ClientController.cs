using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using TestRabbitMQ.Web.Messages;

namespace TestRabbitMQ.Web.ClientService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IBus bus;

        public ClientController(IBus _bus)
        {
            bus = _bus;
        }

        [HttpPost]
        public async Task<string> Post(string name)
        {
            ClientMessage message = new ClientMessage()
            {
                ClientId = 10001,
                ClientName = name,
                Sex = "M",
                Age = 23
            };

            await bus.PublishAsync(message);

            return "Add Client Success! You will receive some letter later.";
        }
    }
}
