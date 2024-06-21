using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IAccountInfoService
    {
        Task<GetPageAccountInfoResModel> GetPageAccountInfoAsync(long tenantId, GetPageAccountInfoReqModel input);
        Task<AccountInfoResModel> GetAccountInfoByIdAsync(long tenantId, long id);
        Task CreateAccount(CreateOrEditAccountReqModel input);
        Task EditAccount(CreateOrEditAccountReqModel input);
        Task DeleteAccount(long id);
    }
}