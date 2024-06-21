using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface ICourseService 
    {
        Task<BasePaginationResModel<CourseResModel>> GetPageCourseAsync(long tenantId, BasePaginationReqModel input);
        Task<CourseResModel> GetInfoCourseAsync(long id);
        Task CreateCourseAsync(long tenantId, CreateEditCourseReqModel input);
        Task EditCourseAsync(long id, CreateEditCourseReqModel input);
        Task DeleteCourseAsync(long id);
        
    }
}
