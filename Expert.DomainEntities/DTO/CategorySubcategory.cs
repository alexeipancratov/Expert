using Expert.DomainEntities.Entities;
using System.Collections.Generic;

namespace Expert.DomainEntities.DTO
{
    public class CategorySubcategory
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Subcategory> Subcategories { get; set; }
    }
}
