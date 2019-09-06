﻿using EasyNetQ;

namespace TestRabbitMQ.Web.Messages
{
    [Queue("Qka.Client", ExchangeName = "Qka.Client")]
    public class ClientMessage
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}
