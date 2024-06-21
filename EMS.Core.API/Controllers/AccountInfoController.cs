using EMS.Core.API.Extensions;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInfoResModel>> GetAccountInfoById(long id)
        {
            var result = await _accountInfoService.GetAccountInfoByIdAsync(TenantId, id);
            return Ok(result);
        }
    }
}
