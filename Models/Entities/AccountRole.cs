using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class AccountRole : BaseEntitySoftDeletable
    {
        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
