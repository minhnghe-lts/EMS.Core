using EMS.Core.Commons;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected long TenantId;
        private readonly IHttpContextAccessor _contextAccessor;

        public BaseController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var contextItems = _contextAccessor.HttpContext.Items;
            long.TryParse(contextItems[CommonConstants.ContextItem.TENANT_ID].ToString(), out TenantId);
        }
    }
}
