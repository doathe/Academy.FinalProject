using AutoMapper;
using ECommerce.Application.Products.Commands.ProductAdd;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ProductCategories.Commands.ProductCategoryAdd
{
    public class ProductCategoryAddDto
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public bool Status { get; set; }
    }

    public class ProductCategoryAddProfile : Profile
    {
        public ProductCategoryAddProfile()
        {
            CreateMap<ProductCategory, ProductCategoryAddDto>()
                .ForPath(destination => destination.CategoryName, operation => operation.MapFrom(source => source.Category.Name))
                .ForPath(destination => destination.ProductName, operation => operation.MapFrom(source => source.Product.Name))
                .ForPath(destination => destination.Status, operation => operation.MapFrom(source => source.Product.Status));
            CreateMap<ProductCategoryAddCommand, ProductCategory>()
                .ForMember(destination => destination.CategoryId, operation => operation.MapFrom(source => source.CategoryId))
                .ForMember(destination => destination.ProductId, operation => operation.MapFrom(source => source.ProductId));
        }
    }
}
