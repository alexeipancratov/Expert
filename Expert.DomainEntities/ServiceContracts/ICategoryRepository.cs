using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression);
    }
}
