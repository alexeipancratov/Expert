using System;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;
using Expert.DomainEntities.DTO;

namespace Expert.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categoriesCollection;
        private readonly IMongoCollection<Subcategory> _subcategoriesCollection;

        public CategoryRepository(ExpertContext context)
        {
            _categoriesCollection = context.Database.GetCollection<Category>("categories");
            _subcategoriesCollection = context.Database.GetCollection<Subcategory>("subcategories");
        }

        public void Create(Category category)
        {
            _categoriesCollection.InsertOne(category);
        }

        public IQueryable<Category> GetCategories()
        {
            return _categoriesCollection.AsQueryable();
        }

        public IQueryable<CategorySubcategory> GetCategoriesWithSubcategories()
        {
            return from c in _categoriesCollection.AsQueryable()
                   join sc in _subcategoriesCollection.AsQueryable()
                   on c.Id equals sc.CategoryId into joinedSubcategories
                   select new CategorySubcategory
                   {
                       Id = c.Id,
                       Description = c.Description,
                       Name = c.Name,
                       Subcategories = joinedSubcategories
                   };
        }

        public Category GetCategory(string categoryId)
        {
            return _categoriesCollection.FindSync(c => c.Id == categoryId).Single();
        }

        public IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression)
        {
            return GetCategories().Where(expression);
        }
    }
}
