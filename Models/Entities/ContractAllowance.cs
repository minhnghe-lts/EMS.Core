using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class ContractAllowance : BaseEntityMasterType
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
