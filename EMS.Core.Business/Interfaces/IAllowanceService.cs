using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using EMS.Core.Models.ResponseModels.ContractAllowance;

namespace EMS.Core.Business.Interfaces
{
    public interface IAllowanceService
    {
        Task<CreateEditAllowanceResModel> CreateAllowanceAsync(long tenantId, CreateEditAllowanceReqModel input);
        Task<CreateEditAllowanceResModel> EditAllowanceAsync(CreateEditAllowanceReqModel input);
        Task<DeleteAllowanceResModel> DeleteAllowanceAsync(DeleteAllowanceReqModel input);
        Task<GetPageAllowanceResModel> GetPageAllowanceAsync(long tenantId, GetPageAllowanceReqModel input);
        Task<GetAllowanceResModel> GetAllowanceByIdAsync(long allowanceId);
    }
}
