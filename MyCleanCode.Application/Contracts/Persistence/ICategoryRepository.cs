using System.Collections.Generic;
using System.Threading.Tasks;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}