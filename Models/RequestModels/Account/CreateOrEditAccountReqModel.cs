using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels
{
    public class CreateOrEditAccountReqModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime History { get; set; }
        public long? EmployeeId { get; set; }
        public ICollection<long> RoleIds { get; set; }
        public ICollection<long> PermissionIds { get; set; }
    }
}
