using Redis.OM.Modeling;

namespace MvcFarmasi.Models
{
    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Basket" })]
    public class Basket
    {
        [RedisIdField][Indexed] public string? Id { get; set; } = Guid.NewGuid().ToString();
        [Indexed(CascadeDepth = 2)] public string? ProductId { get; set; }
    }
}
