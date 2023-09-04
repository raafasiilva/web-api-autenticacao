namespace API.Models.Contracts.BaseModels
{
    public record FilterParamBaseQueryModel
    {
        public FilterParamBaseQueryModel() { }
        public FilterParamBaseQueryModel(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
