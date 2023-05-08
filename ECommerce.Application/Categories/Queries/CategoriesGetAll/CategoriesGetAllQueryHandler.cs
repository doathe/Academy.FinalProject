using AutoMapper;
using ECommerce.Infrastructure.EFCore.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Queries.CategoriesGetAll
{
    public class CategoriesGetAllQueryHandler : IRequestHandler<CategoriesGetAllQuery, List<CategoriesGetAllDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesGetAllQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoriesGetAllDto>> Handle(CategoriesGetAllQuery request, CancellationToken cancellationToken)
        {
            var categoryModel = await _categoryRepository.GetTree();
            if (categoryModel == null)
            {
                throw new ArgumentNullException(nameof(categoryModel));
            }

            List<CategoriesGetAllDto> responseModel = new List<CategoriesGetAllDto>();

            foreach(var item in categoryModel)
            {
                var model = _mapper.Map<CategoriesGetAllDto>(item);
                responseModel.Add(model);
            }

            responseModel.Sort((x, y) => x.Parent.Name.CompareTo(y.Parent.Name));
            return await Task.FromResult(responseModel);
        }
    }
}
