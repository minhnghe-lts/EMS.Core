using System.ComponentModel.DataAnnotations;

namespace EMS.Core.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid Token { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
