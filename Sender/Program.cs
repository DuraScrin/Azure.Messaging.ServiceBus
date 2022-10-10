using Sender;
using Shared;

Console.WriteLine(" Hello, Sender!");

QueueService queueService = new();

for (int i = 0; i < 4; i++)
{
    DataExampleModel dataModel = new();
    dataModel.FirstName = "Testing ServiceBus messages!";
    dataModel.LastName = "Description...";

    Console.WriteLine($"Sending id:{dataModel.Id}");

    await queueService.SendMessageAsync(dataModel, "test-queue");
    Task.Delay(1500).Wait();
}

Console.WriteLine("Sending message done.");




