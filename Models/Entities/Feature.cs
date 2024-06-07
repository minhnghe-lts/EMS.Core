using System.ComponentModel.DataAnnotations;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Models
{
    public class Feature
    {
        [Key]
        public FeatureCode Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}