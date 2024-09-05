using Test2.Entities.Interfaces;

namespace Test2.Entities;

public class User : IUser
{
    public string Id { get; set; }
    public int DeliveryMethod { get; set; }
    public string Address { get; set; }
}
