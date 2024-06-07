using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class ContractBenefit : BaseEntitySoftDeletable
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
    }
}
