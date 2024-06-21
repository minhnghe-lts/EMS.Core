using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPageDepartmentResModel : BasePaginationResModel
    {
        public List<DepartmentResModel> Data { get; set; }
    }

    public class DepartmentResModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string DepartmentLevelName { get; set; }
    }
}
