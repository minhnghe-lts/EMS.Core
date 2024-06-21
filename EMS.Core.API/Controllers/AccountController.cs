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
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResModel<AccountResModel>>> GetPageAccount([FromQuery] GetPageAccountReqModel input)
        {
            var result = await _accountService.GetPageAccountAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResModel>> GetAccountInfoById(long id)
        {
            var result = await _accountService.GetAccountByIdAsync(TenantId, id);
            return Ok(result);
        }
    }
}
