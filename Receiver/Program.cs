using Receiver;
using Shared;
using System.Text.Json;

Console.WriteLine(" Hello, Receiver!");

QueueService queueService = new();
while (true)
{
    string message = await queueService.ReceiveMessageAsync("test-queue");
    DataExampleModel? dataModel = JsonSerializer.Deserialize<DataExampleModel>(message);

    Console.WriteLine(message);
}
