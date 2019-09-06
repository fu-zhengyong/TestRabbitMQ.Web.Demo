using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using TestRabbitMQ.Web.Messages;

namespace TestRabbitMQ.Web.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBus bus;

        public ValuesController(IBus _bus)
        {
            bus = _bus;
        }
        public  IActionResult Get()
        {
            //手动指定订阅
            bus.Subscribe<ClientMessage>("testid", (m) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Got message: {0}", m.ClientName);
                Console.ResetColor();
            });

            return Ok();
        }
    }
}
