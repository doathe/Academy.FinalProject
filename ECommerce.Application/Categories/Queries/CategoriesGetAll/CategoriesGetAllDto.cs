using AutoMapper;
using ECommerce.Application.Users.Queries.UserLogin;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Queries.CategoriesGetAll
{
    public class CategoriesGetAllDto
    {
        public Category Parent { get; set; }
        public List<Category> Childrens { get; set; }
    }
    public class CategoryListAllProfile : Profile
    {
        public CategoryListAllProfile()
        {
            CreateMap<CategoriesGetAllDto, TreeView>()
                .ForMember(destination => destination.Parent, operation => operation.MapFrom(source => source.Parent))
                .ForMember(destination => destination.Children, operation => operation.MapFrom(source => source.Childrens));
            CreateMap<TreeView, CategoriesGetAllDto>()
                .ForMember(destination => destination.Parent, operation => operation.MapFrom(source => source.Parent))
                .ForMember(destination => destination.Childrens, operation => operation.MapFrom(source => source.Children));
        }
    }
}   
