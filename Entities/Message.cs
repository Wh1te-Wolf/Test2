using Test2.Entities.Interfaces;

namespace Test2.Entities;

public class Message : IMessage
{
    public int UserId { get; set; }
    public string MessageText { get; set; }
}
