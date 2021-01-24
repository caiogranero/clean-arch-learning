using System;
using System.Threading.Tasks;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}