using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class EmployeeSchedule : BaseEntitySoftDeletable
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
