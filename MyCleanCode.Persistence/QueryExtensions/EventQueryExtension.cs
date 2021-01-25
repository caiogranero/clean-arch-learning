using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Persistence.QueryExtensions
{
    public static class EventQueryExtension
    {
        public static Task<bool> IsEventNameAndDateUnique(this IQueryable<Event> source, string name, DateTime date)
        {
            return source.AnyAsync(x => x.Name.Equals(name) && x.Date.Date.Equals(date.Date));
        }
    }
}