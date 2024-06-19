using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using EMS.Core.Models.ResponseModels.ContractType;

namespace EMS.Core.Business.Interfaces
{
    public interface IContractTypeService
    {
        Task<GetPageContractTypeResModel> GetPageContractTypeAsync(long tenantId, BasePaginationReqModel input);
        Task<CreateEditContractTypeResModel> CreateContractTypeAsync(long tenatId, CreateEditContractTypeReqModel input);
        Task<CreateEditContractTypeResModel> EditContractTypeAsync(CreateEditContractTypeReqModel input);
        Task<DeleteContractTypeResModel> DeleteContractTypeAsync(DeleteContractTypeReqModel input);
        Task<GetContractTypeResModel> GetContracTypeByIdAsync(long contractTypeId);
    }
}