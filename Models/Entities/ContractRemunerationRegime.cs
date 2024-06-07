using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class ContractRemunerationRegime : BaseEntitySoftDeletable
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long RemunerationRegimeId { get; set; }
        public virtual RemunerationRegime RemunerationRegime { get; set; }
    }
}
