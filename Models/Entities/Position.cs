using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Position : BaseEntityMasterType
    {
        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<PositionRole> PositionRoles { get; set; }
        public virtual ICollection<PositionPermission> PositionPermissions { get; set; }
    }
}
