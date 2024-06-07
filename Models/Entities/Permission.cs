using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Permission : BaseEntityMasterType
    {
        public string Description { get; set; }
        public virtual ICollection<PermissionFeature> PermissionFeatures { get; set; }
    }
}
