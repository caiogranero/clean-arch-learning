using MyCleanCode.Application.Contracts.Persistence;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(CleanCodeContext dbContext) : base(dbContext)
        {
        }
        
    }
}