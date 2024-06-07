using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class RolePermission : BaseEntitySoftDeletable
    {
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
