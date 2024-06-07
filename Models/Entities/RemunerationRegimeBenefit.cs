using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class RemunerationRegimeBenefit : BaseEntitySoftDeletable
    {
        public long RemunerationRegimeId { get; set; }
        public virtual RemunerationRegime Remuneration { get; set; }
        public long BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
    }
}
