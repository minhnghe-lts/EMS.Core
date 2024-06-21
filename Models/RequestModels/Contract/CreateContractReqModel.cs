using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels.Contract
{
    public class CreateOrEditContractReqModel
    {
        public long Id { get; set; }
        public long ContractTypeId { get; set; }
        public long DepartmentId { get; set; }
        public long EmployeeId { get; set; }
        public long PositionId { get; set; }
        public DateTime? ExpireDate { get; set; }

        public DateTime SignedDate { get; set; }
        public ICollection<CreateContractAllowancesReqModel> ContractAllowances { get; set; }
        public ICollection<long> BenefitIds { get; set; }
        public ICollection<long> RemunerationRegimeIds { get; set; }
    }

    public class CreateContractAllowancesReqModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
