using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class StudentAllocation : BaseEntitySoftDeletable
    {
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }
        public long EmployeeScheduleId { get; set; }
        public virtual EmployeeSchedule EmployeeSchedule { get; set; }
    }
}
