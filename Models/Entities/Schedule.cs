using EMS.Core.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Core.Models
{
    public class Schedule : BaseEntityWithTenantSoftDeletable
    {
        private TimeOnly _fromTime;
        private TimeOnly _toTime;
        public string Name { get; set; }
        public string FromTimeText { get; set; }
        public string ToTimeText { get; set; }
        [NotMapped]
        public TimeOnly FromTime => TimeOnly.TryParse(FromTimeText, out _fromTime) ? _fromTime : new TimeOnly(0, 0);
        [NotMapped]
        public TimeOnly ToTime => TimeOnly.TryParse(ToTimeText, out _toTime) ? _toTime : new TimeOnly(23, 59, 59);
        public DayOfWeek DayOfWeek { get; set; }

        public decimal HourlyRate { get; set; }
    }
}
