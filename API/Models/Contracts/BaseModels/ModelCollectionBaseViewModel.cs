using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Contracts.BaseModels
{
    [ExcludeFromCodeCoverage]
    public record ModelCollectionBaseViewModel<Model> where Model : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItens { get; set; }

        public IEnumerable<Model> Data { get; set; }
    }
}
