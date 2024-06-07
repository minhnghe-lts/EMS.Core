using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Department : BaseEntityWithTenantSoftDeletable
    {
        public long? ParentId { get; set; }
        public Department Parent { get; set; }
        public long DepartmentLevelId { get; set; }
        public virtual DepartmentLevel DepartmentLevel { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
    }
}