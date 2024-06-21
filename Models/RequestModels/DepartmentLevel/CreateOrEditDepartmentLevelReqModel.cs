using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels
{
    public class CreateOrEditDepartmentLevelReqModel
    {
        public long Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
    }
}
