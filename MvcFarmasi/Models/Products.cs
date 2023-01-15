using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MvcFarmasi.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Stok { get; set; }
    }
}
