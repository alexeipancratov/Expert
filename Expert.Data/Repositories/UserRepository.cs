using System;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Expert.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpertContext _context;

        public UserRepository(ExpertContext context)
        {
            _context = context;
        }

        public User GetUser(string userId)
        {
            return _context.Database.GetCollection<User>("users").FindSync(u => u.Id == userId).Single();
        }

        public void UpdateUser(User user)
        {
            _context.Database.GetCollection<User>("users").ReplaceOne(u => u.Id == user.Id, user);
        }

        public void CreateUser(User user)
        {
            _context.Database.GetCollection<User>("users").InsertOne(user);
        }   

        public IQueryable<User> GetUsersByFilter(Expression<Func<User, bool>> expression)
        {
            return _context.Database.GetCollection<User>("users").AsQueryable().Where(expression);
        }
    }
}