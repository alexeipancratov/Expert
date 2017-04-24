using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IUserRepository
    {
        User GetUser(string userId);

        void UpdateUser(User user);

        void CreateUser(User user);
    }
}
