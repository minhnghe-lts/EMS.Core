using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected long TenantId;
        public BaseController()
        {
            //long.TryParse(HttpContext.Items[CommonConstants.ContextItem.TENANT_ID].ToString(), out TenantId);
        }
    }
}
