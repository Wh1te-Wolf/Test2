using Test2.Senders.Interfaces;

namespace Test2.Senders;

public class EmailSender : ISender
{
    public bool Send(string message, string address)
    {
        Console.WriteLine($"Sending Email to {address}: {message}");
        return true;
    }
}
