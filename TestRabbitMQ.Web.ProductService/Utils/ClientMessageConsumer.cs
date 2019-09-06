using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using TestRabbitMQ.Web.Messages;

namespace TestRabbitMQ.Web.ProductService.Utils
{
    public class ClientMessageConsumer: IConsumeAsync<ClientMessage>
    {
        [AutoSubscriberConsumer(SubscriptionId = "ClientMessageService.Notice")]
        public Task ConsumeAsync(ClientMessage message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}, I will send one email to client.", message.ClientName);
            System.Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
