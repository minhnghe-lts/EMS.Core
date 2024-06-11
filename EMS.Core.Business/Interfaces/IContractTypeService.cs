using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IContractTypeService
    {
        Task<GetPageContractTypeResModel> GetPageContractTypeAsync(long tenantId, BasePaginationReqModel input);
    }
}