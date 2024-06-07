using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class PermissionFeature : BaseEntitySoftDeletable
    {
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public long FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
