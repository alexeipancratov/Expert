using System;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface IUserRepository
    {
        User GetUser(string userId);

        void UpdateUser(User user);

        void CreateUser(User user);

        IQueryable<User> GetUsersByFilter(Expression<Func<User, bool>> expression);
    }
}
