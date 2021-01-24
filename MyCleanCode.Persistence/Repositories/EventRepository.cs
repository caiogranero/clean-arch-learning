using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCleanCode.Application.Contracts.Persistence;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(CleanCodeContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            return await _dbContext.Events.AnyAsync(x => x.Name.Equals(name) && x.Date.Date.Equals(date.Date));
        }
    }
}