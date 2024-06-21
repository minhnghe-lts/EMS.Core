using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class DepartmentLevelResModel
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
