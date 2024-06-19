using EMS.Core.Commons;
using EMS.Core.Models.Entities;

namespace EMS.Core.Models
{
    public class ContractAllowance : BaseEntityMasterType
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long AllowanceId {  get; set; }
        public virtual Allowance Allowance { get; set; }
    }
}
