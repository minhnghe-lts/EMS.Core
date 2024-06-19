using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels.ContractAllowance
{
    public class GetPageAllowanceResModel : BasePaginationResModel
    {
        public List<AllowanceResModel> Data { get; set; }
    }
    public class AllowanceResModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
