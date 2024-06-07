using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class PositionRole : BaseEntitySoftDeletable
    {
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
