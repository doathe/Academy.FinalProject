using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Categories.Queries.CategoriesGetAll
{
    public class CategoriesGetAllQuery : IRequest<List<CategoriesGetAllDto>>
    {

    }
}
