using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projClassMongoDBAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
