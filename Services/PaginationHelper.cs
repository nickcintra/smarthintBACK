
namespace smarthintAPI.Services
{
    public static class PaginationHelper
    {
        public static PagedResult<T> Paginate<T>(IQueryable<T> query, int pageNumber, int pageSize) where T : class
        {
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var items = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<T>
            {
                Items = items,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public class PagedResult<T> where T : class
        {
            public IEnumerable<T> Items { get; set; }
            public int TotalPages { get; set; }
            public int CurrentPage { get; set; }
            public int PageSize { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
