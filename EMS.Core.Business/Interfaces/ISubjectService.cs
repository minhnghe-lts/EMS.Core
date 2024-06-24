using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface ISubjectService
    {
        Task<BasePaginationResModel<SubjectResModel>> GetPageSubjectAsync(long tenantId, BasePaginationReqModel input);
        Task<SubjectResModel> GetInfoSubjectAsync(long id);
        Task CreateSubjectAsync(long tenantId, CreateEditSubjectReqModel input);
        Task EditSubjectAsync(long id, CreateEditSubjectReqModel input);
        Task DeleteSubjectAsync(long id);

    }
}
