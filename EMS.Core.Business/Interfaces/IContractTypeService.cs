using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IContractTypeService
    {
        Task<BasePaginationResModel<ContractTypeResModel>> GetPageContractTypeAsync(long tenantId, BasePaginationReqModel input);
        Task CreateContractTypeAsync(long tenatId, CreateEditContractTypeReqModel input);
        Task EditContractTypeAsync(long id, CreateEditContractTypeReqModel input);
        Task DeleteContractTypeAsync(long contractTypeId);
        Task<ContractTypeResModel> GetContracTypeByIdAsync(long contractTypeId);
    }
}