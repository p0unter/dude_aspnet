using AutoMapper;
using _7_storepp.Data.Concrete;

namespace _7_storepp.Web.Models;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
}