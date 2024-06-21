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

    public class AllowanceController : BaseController
    {
        private readonly IAllowanceService _contracAllowanceService;

        public AllowanceController(IAllowanceService contracAllowanceService , IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _contracAllowanceService = contracAllowanceService;
        }      
        [HttpPost]
        public async Task<IActionResult> CreateAllowanceAsync([FromBody] CreateEditAllowanceReqModel input)
        {
            await _contracAllowanceService.CreateAllowanceAsync(TenantId, input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditAllowanceAsync(long id,[FromBody]CreateEditAllowanceReqModel input)
        {
            await _contracAllowanceService.EditAllowanceAsync(id, input);
            return Ok();
        }
        [HttpDelete("{allowanceId}")]
        public async Task<ActionResult> DeleteAllowanceAsync(long allowanceId)
        {
            await _contracAllowanceService.DeleteAllowanceAsync(allowanceId);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BasePaginationResModel<AllowanceResModel>>> GetPageAllowanceAsync([FromQuery]GetPageAllowanceReqModel input)
        {
            var result = await _contracAllowanceService.GetPageAllowanceAsync(TenantId, input);
            return Ok(result);
        }
        [HttpGet("{allowanceId}")]
        public async Task<ActionResult> GetPageAllowanceByIdAsync(long allowanceId)
        {
            return Ok(await _contracAllowanceService.GetAllowanceByIdAsync(allowanceId));
        }


    }
}
