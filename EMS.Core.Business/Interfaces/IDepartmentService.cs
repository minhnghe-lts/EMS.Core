using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<GetPageDepartmentResModel> GetPageDepartmentAsync(long tenantId, GetPageDepartmentReqModel input);
        Task<DepartmentResModel> GetDepartmentByIdAsync(long tenantId, long id);
        Task CreateDepartment(long tenantId, CreateOrEditDepartmentReqModel input);
        Task EditDepartment(CreateOrEditDepartmentReqModel input);
        Task DeleteDepartment(long id);
    }
}