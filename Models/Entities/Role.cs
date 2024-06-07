using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Role : BaseEntityMasterType
    {
        public string Description { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}