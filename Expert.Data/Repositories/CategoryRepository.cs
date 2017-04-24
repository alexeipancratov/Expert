using System;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpertContext _context;

        public CategoryRepository(ExpertContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Database.GetCollection<Category>("categories").InsertOne(category);
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Database.GetCollection<Category>("categories").AsQueryable();
        }

        public Category GetCategory(string categoryId)
        {
            return _context.Database.GetCollection<Category>("categories").FindSync(c => c.Id == categoryId).Single();
        }

        public IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression)
        {
            return GetCategories().Where(expression);
        }
    }
}
