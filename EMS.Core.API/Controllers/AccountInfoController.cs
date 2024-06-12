using EMS.Core.API.Extensions;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route(CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    public class AccountInfoController : BaseController
    {
        private readonly IAccountInfoService _accountInfoService;

        public AccountInfoController(IAccountInfoService accountInfoService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _accountInfoService = accountInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<GetPageAccountInfoResModel>> GetPageAccountInfo([FromQuery] GetPageAccountInfoReqModel input)
        {
            var result = await _accountInfoService.GetPageAccountInfoAsync(TenantId, input);
            return Ok(result);
        }
    }
}
