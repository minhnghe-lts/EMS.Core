using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IAccountInfoService
    {
        Task<GetPageAccountInfoResModel> GetPageAccountInfoAsync(long tenantId, BasePaginationReqModel input);
    }
}