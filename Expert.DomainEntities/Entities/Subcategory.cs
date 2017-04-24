using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Expert.DomainEntities.Entities
{
    public class Subcategory : CoreEntity
    {
        public Subcategory()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        public string Name { get; set; }

        [Required]
        public string CategoryId { get; set; }
    }
}
