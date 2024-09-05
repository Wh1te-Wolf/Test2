using Test2.Entities;
using Test2.Entities.Interfaces;
using Test2.Repositories.Interfaces;

namespace Test2.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Dictionary<int, IUser> _users;

    public UserRepository()
    {
        _users = new Dictionary<int, IUser>
        {
            { 1, new User { Id = "1", DeliveryMethod = 1, Address = "@user1" } },
            { 2, new User { Id = "2", DeliveryMethod = 2, Address = "+1234567890" } },
            { 3, new User { Id = "3", DeliveryMethod = 3, Address = "user3@example.com" } }
        };
    }

    public IUser Get(int userId)
    {
        return _users.TryGetValue(userId, out var user) ? user : null;
    }
}
