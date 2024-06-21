using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPageContractResModel : BasePaginationResModel
    {
        public List<ContractResModel> Data { get; set; }
    }

    public class ContractResModel
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string ContractType { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
