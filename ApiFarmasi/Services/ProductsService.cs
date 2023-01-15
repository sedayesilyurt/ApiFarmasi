using ApiFarmasi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace ApiFarmasi.Services
{
    public class ProductsService
    {
        private readonly IMongoCollection<Products> _productCollection;

        public ProductsService(IOptions<ProductFarmasiDatabaseSettings> productstoredatabasesettings)
        {
            var mongoClient = new MongoClient(productstoredatabasesettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(productstoredatabasesettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<Products>(productstoredatabasesettings.Value.ProductsCollectionName);
        }

        public async Task<List<Products>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<Products?> GetAsync(string id) =>
            await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Products newproduct)=>
            await _productCollection.InsertOneAsync(newproduct);

        public async Task UpdateAsync(string id, Products updatedProduct) =>
            await _productCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

        public async Task RemoveAsync(string id) =>
            await _productCollection.DeleteOneAsync(x => x.Id == id);

    }
}
