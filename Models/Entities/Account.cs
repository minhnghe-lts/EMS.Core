using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Account : BaseEntityWithTenantSoftDeletable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime History { get; set; }
        public bool IsActive { get; set; }
        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual ICollection<AccountPermission> AccountPermissions { get; set; }
    }
}
