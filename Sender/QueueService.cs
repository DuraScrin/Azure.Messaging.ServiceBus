using Azure.Messaging.ServiceBus;
using System.Text.Json;

namespace Sender
{
    public class QueueService
    {
        private string connectionString { get; set; }
        public QueueService() //pass your configuration here
        {
            connectionString = "Endpoint=sb://duraware.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lAtNIR/G/r4zwD+0p5VqRkd5yXJzlR1JoxO2HbvILFI=";
        }

        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            await using var client = new ServiceBusClient(connectionString);

            //create a message.
            string messageBody = JsonSerializer.Serialize(serviceBusMessage);
            ServiceBusMessage message = new ServiceBusMessage(messageBody); //UTF-8 encoding is used when providing a string.

            //create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            //send the message
            try
            {
                await sender.SendMessageAsync(message);
            }
            catch (ServiceBusException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
