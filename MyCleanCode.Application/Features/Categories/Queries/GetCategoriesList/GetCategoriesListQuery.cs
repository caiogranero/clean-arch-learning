using System.Collections.Generic;
using MediatR;

namespace MyCleanCode.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
        
    }
}