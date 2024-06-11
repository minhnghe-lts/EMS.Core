namespace EMS.Core.Models.ResponseModels
{
    public class BasePaginationResModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
