using EMS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.Entities
{
    public class Allowance : BaseEntityMasterType
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<ContractAllowance> ContractAllowances { get; set;}
    }
}
