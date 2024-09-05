using Test2.Senders.Interfaces;

namespace Test2.Senders;

public class SmsSender : ISender
{
    public bool Send(string message, string address)
    {
        Console.WriteLine($"Sending SMS to {address}: {message}");
        return true;
    }
}
