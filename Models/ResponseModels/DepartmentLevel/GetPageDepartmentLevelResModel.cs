using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPageDepartmentLevelResModel : BasePaginationResModel
    {
        public List<DepartmentLevelResModel> Data { get; set; }
    }

    public class DepartmentLevelResModel
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
