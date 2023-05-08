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

namespace ECommerce.Application.Products.Commands.ProductAdd
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, ProductAddDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductAddCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductAddDto> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Product>(request);
            await _productRepository.AddAsync(model);

            var repsonseModel = _mapper.Map<ProductAddDto>(model);
            return await Task.FromResult(repsonseModel);
        }
    }
}
