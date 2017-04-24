using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Expert.DomainEntities.Entities
{
    public class Subcategory : CoreEntity
    {
        public string Name { get; set; }

        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
    }
}
