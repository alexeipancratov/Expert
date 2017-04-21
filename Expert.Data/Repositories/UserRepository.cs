using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpertContext _context;

        public UserRepository(ExpertContext context)
        {
            _context = context;
        }

        public User GetUser(string ldapId)
        {
            return _context.Database.GetCollection<User>("users").FindSync(u => u.Id == ldapId).Single();
        }

        public void UpdateUser(User user)
        {
            _context.Database.GetCollection<User>("users").ReplaceOne(u => u.Id == user.Id, user);
        }

        public void CreateUser(User user)
        {
            _context.Database.GetCollection<User>("users").InsertOne(user);
        }
    }
}