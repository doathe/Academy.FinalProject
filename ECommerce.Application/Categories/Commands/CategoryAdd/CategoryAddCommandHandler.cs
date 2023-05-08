using AutoMapper;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Commands.CategoryAdd
{
    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, CategoryAddDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryAddCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryAddDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Category>(request);
            if (model == null) 
            { 
                throw new ArgumentNullException(nameof(model));
            }
            await _categoryRepository.AddAsync(model);
            var reponseModel = _mapper.Map<CategoryAddDto>(model);
            return await Task.FromResult(reponseModel);
        }
    }
}
