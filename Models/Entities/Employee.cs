using EMS.Core.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Core.Models
{
    public class Employee : BaseEntityWithTenantSoftDeletable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public long? DirectManagerId { get; set; }
        public virtual Employee DirectManager { get; set; }
        public bool IsActive { get; set; }
        public bool IsTeacher { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
    }
}