﻿using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Interfaces
{
    public interface IDepartmentLevelService
    {
        Task<BasePaginationResModel<DepartmentLevelResModel>> GetPageDepartmentLevel(long tenantId, GetPageDepartmentLevelReqModel input);
        Task<DepartmentLevelResModel> GetDepartmentLevelByIdAsync(long tenantId, long id);
        Task CreateDepartmentLevel(long tenantId, CreateOrEditDepartmentLevelReqModel input);
        Task EditDepartmentLevel(long id, CreateOrEditDepartmentLevelReqModel input);
        Task DeleteDepartmentLevel(long id);
    }
}