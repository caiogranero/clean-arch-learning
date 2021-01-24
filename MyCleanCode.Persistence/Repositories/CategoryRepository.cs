using System.Collections.Generic;
using System.Linq;
using MyCleanCode.Application.Contracts.Persistence;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CleanCodeContext dbContext) : base(dbContext)
        {
        }
    }
}