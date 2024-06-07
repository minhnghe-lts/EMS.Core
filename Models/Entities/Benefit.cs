using EMS.Core.Commons;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Models
{
    public class Benefit : BaseEntityMasterType
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsPayWithSalary { get; set; }
        public PayMonth PayMonth { get; set; }
        public DateTime? PayDate { get; set; }
        public virtual ICollection<BenefitDepartment> BenefitDepartments { get; set; }
        public virtual ICollection<BenefitPosition> BenefitPositions { get; set; }
    }
}
