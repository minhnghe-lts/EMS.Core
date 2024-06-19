using EMS.Core.Models.RequestModels.ContractAllowance;
using EMS.Core.Models.ResponseModels.ContractAllowance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Business.Interfaces
{
    public interface IAllowanceService
    {
        Task<CreateEditAllowanceResModel> CreateAllowanceAsync(long tenantId, CreateEditAllowanceReqModel input);
        Task<CreateEditAllowanceResModel> EditAllowanceAsync(CreateEditAllowanceReqModel input);
        Task<DeleteAllowanceResModel> DeleteAllowanceAsync(DeleteAllowanceReqModel input);
        Task<GetPageAllowanceResModel> GetPageAllowanceAsync(long tenantId, GetPageAllowanceReqModel input);
    }
}
