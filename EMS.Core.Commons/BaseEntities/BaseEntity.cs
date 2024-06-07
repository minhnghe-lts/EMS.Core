using System.ComponentModel.DataAnnotations;

namespace EMS.Core.Commons
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
