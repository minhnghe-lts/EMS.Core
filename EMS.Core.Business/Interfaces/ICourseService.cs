using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface ICourseService 
    {
        Task<GetPageCourseResModel> GetPageCourseAsync(long tenantId, BasePaginationReqModel input);
        Task<GetInfoCourseResModel> GetInfoCourseAsync(long tenantId, GetInfoCourseReqModel input);
        Task CreateCourseAsync(long tenantId, CreateEditCourseReqModel input);
        Task EditCourseAsync(long tenantId, CreateEditCourseReqModel input);
        Task DeleteCourseAsync(long tenantId, DeleteCourseReqModel courseId);
        
    }
}
