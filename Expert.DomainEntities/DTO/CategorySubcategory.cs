using Expert.DomainEntities.Entities;
using System.Collections.Generic;

namespace Expert.DomainEntities.DTO
{
    public class CategorySubcategory : Category
    {
        public IEnumerable<Subcategory> Subcategories { get; set; }
    }
}
