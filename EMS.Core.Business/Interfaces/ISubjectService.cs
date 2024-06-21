using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface ISubjectService
    {
        Task<GetPageSubjectResModel> GetPageSubjectAsync(long tenantId, BasePaginationReqModel input);
        Task<GetInfoSubjectResModel> GetInfoSubjectAsync(long tenantId, GetInfoSubjectReqModel input);
        Task CreateSubjectAsync(long tenantId, CreateEditSubjectReqModel input);
        Task EditSubjectAsync(long tenantId, CreateEditSubjectReqModel input);
        Task DeleteSubjectAsync(long tenantId, DeleteSubjectReqModel input);

    }
}
