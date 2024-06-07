using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class BenefitDepartment : BaseEntitySoftDeletable
    {
        public long BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
