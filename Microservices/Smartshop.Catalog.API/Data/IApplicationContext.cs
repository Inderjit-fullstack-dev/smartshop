using MongoDB.Driver;
using Smartshop.Catalog.API.Entities;

namespace Smartshop.Catalog.API.Data
{
    public interface IApplicationContext
    {
        IMongoCollection<Product> Products { get; set; }
    }
}
