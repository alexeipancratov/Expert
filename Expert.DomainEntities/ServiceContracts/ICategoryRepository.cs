using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.DTO;
using Expert.DomainEntities.Entities;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();

        IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression);

        IEnumerable<CategorySubcategory> GetCategoriesWithSubcategories();

        Category GetCategory(string categoryId);

        void Create(Category category);
    }
}
