using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Smartshop.Catalog.API.Entities;

namespace Smartshop.Catalog.API.Data
{
    public class ApplicationContext : IApplicationContext
    {
        private const string ProductCollectionName = "products";
        public ApplicationContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDB:DefaultConnection"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoDB:DatabaseName"));
            Products = database.GetCollection<Product>(ProductCollectionName);
        }

        public IMongoCollection<Product> Products { get; set; }
    }
}
