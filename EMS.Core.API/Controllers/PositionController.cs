using EMS.Core.API.Extensions;
using EMS.Core.Business.Implements;
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
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult<GetPagePositionResModel>> GetPagePosition([FromQuery] GetPagePositionReqModel input)
        {
            var result = await _positionService.GetPagePositonAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionResModel>> GetPositionById(long id)
        {
            var result = await _positionService.GetPositionByIdAsync(TenantId, id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition(long tenentId, [FromBody] CreateOrEditPositionReqModel input)
        {
            await _positionService.CreatePosition(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditPosition([FromBody] CreateOrEditPositionReqModel input)
        {
            await _positionService.EditPosition(input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(long id)
        {
            await _positionService.DeletePosition(id);
            return Ok();
        }
    }
}
