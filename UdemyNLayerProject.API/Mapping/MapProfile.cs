using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();
            CreateMap<Product, ProductWithCategory>().ReverseMap();
        }
    }
}
