using AutoMapper;
using Dal_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service_layer.MappingProfile
{
    public class MyAppProfile : Profile
    {
        public MyAppProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
        
    }
}
