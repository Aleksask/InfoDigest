using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace InfoDigest.WebAPI.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if(source == null)
                throw new ArgumentException("source");
            if (string.IsNullOrEmpty(sort))
                return source;

            var lstSort = sort.Split(',');

            var sortOptions = lstSort.Select(sortOption => sortOption.StartsWith("-")
                ? $"{sortOption.Remove(0, 1)} descending"
                : $"{sortOption}")
                .ToList();

            if (sortOptions.Count > 0)
            {
                source = source.OrderBy(string.Join(",", sortOptions));
            }
            return source;
        }
    }
}