using AutoMapper;
using ECommerce.Application.Users.Commands.UserRegistration;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Products.Commands.ProductAdd
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
    public class ProductAddProfile : Profile
    {
        public ProductAddProfile()
        {
            CreateMap<Product, ProductAddDto>().ReverseMap()
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
                .ForMember(destination => destination.Status, operation => operation.MapFrom(source => source.Status));
            CreateMap<ProductAddCommand, Product>()
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.ProductName))
                .ForMember(destination => destination.Price, operation => operation.MapFrom(source => source.ProductPrice))
                .ForMember(destination => destination.Inventory, operation => operation.MapFrom(source => source.ProductInventory));
        }
    }
}
