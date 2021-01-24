using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Contracts.Persistence
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        
    }
}