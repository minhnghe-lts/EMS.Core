using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class PositionPermission : BaseEntitySoftDeletable
    {
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
