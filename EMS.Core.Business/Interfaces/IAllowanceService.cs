using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IAllowanceService
    {
        Task CreateAllowanceAsync(long tenantId, CreateEditAllowanceReqModel input);
        Task EditAllowanceAsync(long id, CreateEditAllowanceReqModel input);
        Task DeleteAllowanceAsync(long allowanceId);
        Task<BasePaginationResModel<AllowanceResModel>> GetPageAllowanceAsync(long tenantId, GetPageAllowanceReqModel input);
        Task<AllowanceResModel> GetAllowanceByIdAsync(long allowanceId);
    }
}
