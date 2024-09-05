using Test2.Senders.Interfaces;

namespace Test2.Senders;

public class WhatsAppSender : ISender
{
    public bool Send(string message, string address)
    {
        Console.WriteLine($"Sending WhatsApp message to {address}: {message}");
        return true;
    }
}
