using EMS.Core.Models.RequestModels;
using EMS.Core.Models.RequestModels.Contract;
using EMS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Business.Interfaces
{
    public interface IContractService
    {
        Task<BasePaginationResModel<ContractResModel>> GetPageContractAsync(long tenantId, BasePaginationReqModel input);
        Task CreateContract(long tenantId, CreateOrEditContractReqModel input);
        Task EditContract(long id, CreateOrEditContractReqModel input);
        Task DeleteContract(long id);
    }
}
