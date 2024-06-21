using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels
{
    public class CreateOrEditDepartmentReqModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long DepartmentLevelId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<long> PositionIds { get; set; }
        public virtual ICollection<long> DepartmentManagerIds { get; set; }
    }
}
