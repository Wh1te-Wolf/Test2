using Test2.Entities.Interfaces;

namespace Test2.Repositories.Interfaces;

public interface IUserRepository
{
    IUser Get(int userId);
}
