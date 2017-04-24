using Expert.DomainEntities.ServiceContracts;
using System.Linq;
using Expert.DomainEntities.Entities;
using MongoDB.Driver;

namespace Expert.Data.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly IMongoCollection<Subcategory> _collection;

        public SubcategoryRepository(ExpertContext context)
        {
            _collection = context.Database.GetCollection<Subcategory>("subcategories");
        }

        public void Create(Subcategory subcategory)
        {
            _collection.InsertOne(subcategory);
        }

        public IQueryable<Subcategory> GetSubcategories()
        {
            return _collection.AsQueryable();
        }

        public Subcategory GetSubcategory(string subcategoryId)
        {
            return _collection.FindSync(sc => sc.Id == subcategoryId).Single();
        }
    }
}
