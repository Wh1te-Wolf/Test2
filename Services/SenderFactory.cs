using Test2.Senders.Interfaces;
using Test2.Senders;

namespace Test2.Services;

public class SenderFactory
{
    public static IDictionary<int, ISender> CreateSenders()
    {
        return new Dictionary<int, ISender>
        {
            { 1, new TelegramSender() },
            { 2, new SmsSender() },
            { 3, new EmailSender() },
            { 4, new WhatsAppSender() }
        };
    }
}
