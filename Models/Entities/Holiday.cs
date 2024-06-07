using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class Holiday : BaseEntityMasterType
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal HourlyRate { get; set; } = 1;
    }
}
