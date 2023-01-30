using MongoDB.Driver;
using Smartshop.Catalog.API.Entities;

namespace Smartshop.Catalog.API.Data
{
    interface IApplicationContext
    {
        IMongoCollection<Product> Products { get; set; }
    }
}
