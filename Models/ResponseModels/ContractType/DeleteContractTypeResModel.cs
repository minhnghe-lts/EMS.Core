using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels.ContractType
{
    public class DeleteContractTypeResModel
    {
        public long Id {  get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
