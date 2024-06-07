using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class DepartmentManager : BaseEntitySoftDeletable
    {
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
