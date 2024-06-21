namespace EMS.Core.Models.ResponseModels
{
    public class BasePaginationResModel<T> where T : class
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
    }
}
