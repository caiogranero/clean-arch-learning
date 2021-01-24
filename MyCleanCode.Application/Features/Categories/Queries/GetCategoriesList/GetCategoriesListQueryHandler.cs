using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyCleanCode.Persistence;
using MyCleanCode.Persistence.Repository;

namespace MyCleanCode.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly CleanCodeContext _dbContext;

        public GetCategoriesListQueryHandler(IMapper mapper, CleanCodeContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _dbContext.Categories.FindByName("").ToListAsync(cancellationToken: cancellationToken)).OrderBy(x => x.Name);

            return _mapper.Map<List<CategoryListVm>>(allCategories);

        }
    }

    
}