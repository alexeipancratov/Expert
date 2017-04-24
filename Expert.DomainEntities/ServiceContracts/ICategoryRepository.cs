using System;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.DTO;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();

        IQueryable<CategorySubcategory> GetCategoriesWithSubcategories();

        IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression);

        Category GetCategory(string categoryId);

        void Create(Category category);
    }
}
