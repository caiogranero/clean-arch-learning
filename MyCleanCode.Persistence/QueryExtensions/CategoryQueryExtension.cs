using System.Linq;
using MyCleanCode.Domain.Entities;

namespace MyCleanCode.Persistence.QueryExtensions
{
    public static class CategoryQueryExtension
    {
        public static IQueryable<Category> FindByName(this IQueryable<Category> source, string name)
        {
            return source.Where(x => x.Name == name);
        }
    }
}