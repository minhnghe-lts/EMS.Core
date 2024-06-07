using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class BenefitPosition : BaseEntitySoftDeletable
    {
        public long BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
