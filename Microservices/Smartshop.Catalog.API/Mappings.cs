using AutoMapper;
using Smartshop.Catalog.API.Entities;
using Smartshop.Catalog.API.ViewModels;

namespace Smartshop.Catalog.API
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
