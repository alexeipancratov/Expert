using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Expert.DomainEntities.DTO;
using Expert.DomainEntities.Entities;
using Expert.DomainEntities.ServiceContracts;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _collection;

        public CategoryRepository(ExpertContext context)
        {
            _collection = context.Database.GetCollection<Category>("categories");
        }

        public void Create(Category category)
        {
            _collection.InsertOne(category);
        }

        public IQueryable<Category> GetCategories()
        {
            return _collection.AsQueryable();
        }

        public IEnumerable<CategorySubcategory> GetCategoriesWithSubcategories()
        {
            var query = from c in _collection.FindSync(c => c.ParentId == null).ToList()
                        join cc in _collection.FindSync(cc => cc.ParentId != null).ToList()
                        on c.Id equals cc.ParentId
                        into subcategories
                        select new CategorySubcategory
                        {
                            Id = c.Id,
                            Description = c.Description,
                            PictureUrl = c.PictureUrl,
                            Name = c.Name,
                            Subcategories = subcategories
                        };

            return query;
        }

        public Category GetCategory(string categoryId)
        {
            return _collection.FindSync(c => c.Id == categoryId).Single();
        }

        public IQueryable<Category> GetCategoryByFilter(Expression<Func<Category, bool>> expression)
        {
            return GetCategories().Where(expression);
        }
    }
}
