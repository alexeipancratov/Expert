using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IUserRepository
    {
        User GetUser(string ldapId);

        void UpdateUser(User user);
    }
}
