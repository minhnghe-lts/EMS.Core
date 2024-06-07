using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Contract : BaseEntitySoftDeletable
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public long ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public bool IsActive { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public virtual ICollection<ContractAllowance> ContractAllowances { get; set; }
        public virtual ICollection<ContractBenefit> ContractBenefits { get; set; }
        public virtual ICollection<ContractRemunerationRegime> ContractRemunerationRegimes { get; set; }

    }
}
