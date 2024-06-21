using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<BasePaginationResModel<DepartmentResModel>> GetPageDepartmentAsync(long tenantId, GetPageDepartmentReqModel input);
        Task<DepartmentResModel> GetDepartmentByIdAsync(long tenantId, long id);
        Task CreateDepartment(long tenantId, CreateOrEditDepartmentReqModel input);
        Task EditDepartment(long id, CreateOrEditDepartmentReqModel input);
        Task DeleteDepartment(long id);
    }
}