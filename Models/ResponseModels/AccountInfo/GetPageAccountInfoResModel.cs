using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPageAccountInfoResModel : BasePaginationResModel
    {
        public List<AccountInfoResModel> Data { get; set; }
    }

    public class AccountInfoResModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
    }
}
