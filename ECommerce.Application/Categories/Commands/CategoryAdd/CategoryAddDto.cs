using AutoMapper;
using ECommerce.Application.Categories.Queries.CategoriesGetAll;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Commands.CategoryAdd
{
    public class CategoryAddDto
    {
        public string CategoryName { get; set; }
    }
    public class CategoryAddProfile : Profile
    {
        public CategoryAddProfile()
        {
            CreateMap<CategoryAddCommand, Category>()
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.CategoryName))
                .ForMember(destination => destination.ParentCategoryId, operation => operation.MapFrom(source => source.ParentCategoryId));
            CreateMap<CategoryAddDto, Category>().ReverseMap()
                .ForMember(destination => destination.CategoryName, operation => operation.MapFrom(source => source.Name));
        }
    }
}
