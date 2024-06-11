namespace EMS.Core.Models.RequestModels
{
    public class BasePaginationReqModel
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
