using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class RemunerationRegime : BaseEntityMasterType
    {
        public virtual ICollection<RemunerationRegimeBenefit> RemunerationRegimeBenefits { get; set; }
    }
}
