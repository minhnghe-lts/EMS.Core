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
    public class DepartmentLevelController : BaseController
    {
        private readonly IDepartmentLevelService _departmentLevelService;

        public DepartmentLevelController(IDepartmentLevelService departmentLevelService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _departmentLevelService = departmentLevelService;
        }

        [HttpGet]
        public async Task<ActionResult<GetPageDepartmentLevelResModel>> GetPageDepartmentLevel([FromQuery] GetPageDepartmentLevelReqModel input)
        {
            var result = await _departmentLevelService.GetPageDepartmentLevel(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentLevelResModel>> GetDepartmentLevelById(long id)
        {
            var result = await _departmentLevelService.GetDepartmentLevelByIdAsync(TenantId, id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartmentLevel(long tenentId, [FromBody]CreateOrEditDepartmentLevelReqModel input)
        {
            await _departmentLevelService.CreateDepartmentLevel(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditDepartmentLevel([FromBody] CreateOrEditDepartmentLevelReqModel input)
        {
            await _departmentLevelService.EditDepartmentLevel(input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentLevel(long id)
        {
            await _departmentLevelService.DeleteDepartmentLevel(id);
            return Ok();
        }
    }
}
