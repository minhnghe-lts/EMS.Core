using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels
{
    public class CreateOrEditPositionReqModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? DepartmentId { get; set; }
        public ICollection<long> PositionRoleIds { get; set; }
        public  ICollection<long> PositionPermissionIds { get; set; }
    }
}
