using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Expert.DomainEntities.Entities
{
    public class CoreEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
