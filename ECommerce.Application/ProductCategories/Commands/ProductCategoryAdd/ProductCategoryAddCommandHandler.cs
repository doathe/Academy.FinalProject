using AutoMapper;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Infrastructure.EFCore.Repositories.Interfaces;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ProductCategories.Commands.ProductCategoryAdd
{
    public class ProductCategoryAddCommandHandler : IRequestHandler<ProductCategoryAddCommand, ProductCategoryAddDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryAddCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public Task<ProductCategoryAddDto> Handle(ProductCategoryAddCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<ProductCategory>(request);
            _productCategoryRepository.AddAsync(model);

            var responseModel = _mapper.Map<ProductCategoryAddDto>(model);
            return Task.FromResult(responseModel);
        }
    }
}
