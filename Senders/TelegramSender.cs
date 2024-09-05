using Test2.Senders.Interfaces;

namespace Test2.Senders;

public class TelegramSender : ISender
{
    public bool Send(string message, string address)
    {
        Console.WriteLine($"Sending Telegram message to {address}: {message}");
        return true;
    }
}
