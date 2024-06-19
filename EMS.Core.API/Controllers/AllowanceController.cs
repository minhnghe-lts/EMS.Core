using EMS.Core.API.Extensions;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels.ContractAllowance;
using EMS.Core.Models.ResponseModels.ContractAllowance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route(CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]

    public class AllowanceController : BaseController
    {
        private readonly IAllowanceService _contracAllowanceService;

        public AllowanceController(IAllowanceService contracAllowanceService , IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _contracAllowanceService = contracAllowanceService;
        }      
        [HttpPost]
        public async Task<IActionResult> CreateAllowanceAsync([FromQuery] CreateEditAllowanceReqModel input)
        {
            return Ok(await _contracAllowanceService.CreateAllowanceAsync(TenantId, input));
        }
        [HttpPut]
        public async Task<ActionResult> EditAllowanceAsync([FromQuery]CreateEditAllowanceReqModel input)
        {
            return Ok(await _contracAllowanceService.EditAllowanceAsync(input));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAllowanceAsync([FromQuery] DeleteAllowanceReqModel input)
        {
            return Ok(await _contracAllowanceService.DeleteAllowanceAsync(input));
        }
        [HttpGet]
        public async Task<ActionResult<GetPageAllowanceResModel>> GetPageAllowanceAsync([FromQuery]GetPageAllowanceReqModel input)
        {
            return Ok(await _contracAllowanceService.GetPageAllowanceAsync(TenantId,input));
        }


    }
}
