using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels.Contract
{
    public class CreateOrUpdateContractReqModel
    {
        public int Id { get; set; }
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public bool IsActive { get; set; }
        public long ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public DateTime SignedDate { get; set; }
        public virtual ICollection<ContractAllowance> ContractAllowances { get; set; }
        public virtual ICollection<long> BenefitIds { get; set; }
        public virtual ICollection<long> RemunerationRegimeIds { get; set; }
    }
}
