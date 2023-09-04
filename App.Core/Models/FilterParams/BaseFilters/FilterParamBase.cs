namespace App.Domain.Models.FilterParams.BaseFilters
{
    public record FilterParamBase
    {
        public FilterParamBase() { }
        public FilterParamBase(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
