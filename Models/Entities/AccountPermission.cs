using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class AccountPermission : BaseEntitySoftDeletable
    {
        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
        public long PermissionId { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
