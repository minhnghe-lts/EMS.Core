using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPagePositionResModel : BasePaginationResModel
    {
        public List<PositionResModel> Data { get; set; }
    }

    public class PositionResModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
    }
}
