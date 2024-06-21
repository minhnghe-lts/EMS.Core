using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IPositionService
    {
        Task<BasePaginationResModel<PositionResModel>> GetPagePositonAsync(long tenantId, GetPagePositionReqModel input);
        Task<PositionResModel> GetPositionByIdAsync(long tenantId, long id);
        Task CreatePosition(long tenantId, CreateOrEditPositionReqModel input);
        Task EditPosition(long id, CreateOrEditPositionReqModel input);
        Task DeletePosition(long id);
    }
}