using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IAccountService
    {
        Task<BasePaginationResModel<AccountResModel>> GetPageAccountAsync(long tenantId, GetPageAccountReqModel input);
        Task<AccountResModel> GetAccountByIdAsync(long tenantId, long id);
        Task CreateAccount(CreateOrEditAccountReqModel input);
        Task EditAccount(long id, CreateOrEditAccountReqModel input);
        Task DeleteAccount(long id);
    }
}