using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Tenant : BaseEntitySoftDeletable
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
