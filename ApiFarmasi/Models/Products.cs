using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiFarmasi.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int ProductPice { get; set; }
    }
}
