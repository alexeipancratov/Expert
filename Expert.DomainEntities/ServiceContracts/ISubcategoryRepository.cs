using Expert.DomainEntities.Entities;
using System.Linq;

namespace Expert.DomainEntities.ServiceContracts
{
    public interface ISubcategoryRepository
    {
        IQueryable<Subcategory> GetSubcategories();

        Subcategory GetSubcategory(string subcategoryId);

        void Create(Subcategory subcategory);
    }
}
