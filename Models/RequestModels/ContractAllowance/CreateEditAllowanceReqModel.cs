using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.RequestModels.ContractAllowance
{
    public class CreateEditAllowanceReqModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
