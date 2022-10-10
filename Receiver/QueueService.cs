using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
namespace Receiver
{
    internal class QueueService
    {
        private string connectionString { get; set; }
        public QueueService() //pass your configuration here
        {
            connectionString = "Endpoint=sb://duraware.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lAtNIR/G/r4zwD+0p5VqRkd5yXJzlR1JoxO2HbvILFI=";
        }

        public async Task<string> ReceiveMessageAsync(string queueName)
        {
            //ServiceBusClientOptions options = new ();
            //options.m
            await using var client = new ServiceBusClient(connectionString);

            // create a receiver that we can use to receive the message
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            await receiver.CompleteMessageAsync(receivedMessage);
            //await receiver.DeadLetterMessageAsync(receivedMessage);

            // get the message body as a string
            return receivedMessage.Body.ToString();
        }
    }
}
