using Test2.Entities.Interfaces;
using Test2.Entities;
using Test2.Repositories;
using Test2.Services;

namespace Test2;

public class Program
{
    static void Main(string[] args)
    {
        var userRepository = new UserRepository();
        var senders = SenderFactory.CreateSenders();
        var maxTotalThreads = 10;
        var maxThreadsPerMethod = new Dictionary<int, int>
        {
            { 1, 3 }, // Telegram
            { 2, 3 }, // SMS
            { 3, 3 }, // Email
            { 4, 1 }  // WhatsApp
        };

        var postman = new Postman(userRepository, senders, maxTotalThreads, maxThreadsPerMethod);

        var messages = new List<IMessage>
        {
            new Message { UserId = 1, MessageText = "Hello via Telegram" },
            new Message { UserId = 2, MessageText = "Hello via SMS" },
            new Message { UserId = 3, MessageText = "Hello via Email" },
            new Message { UserId = 4, MessageText = "Hello via WhatsApp" },
            new Message { UserId = 5, MessageText = "This will fail" }
        };

        postman.SendAsync(messages);

        Console.WriteLine("Message sending completed.");
        Console.WriteLine($"Failed messages: {postman.FailedMessages.Count}");

        foreach (var failedMessage in postman.FailedMessages)
        {
            Console.WriteLine($"Failed to send message to user {failedMessage.UserId}: {failedMessage.MessageText}");
        }
    }
}
