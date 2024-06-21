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
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<BasePaginationResModel<DepartmentResModel>>> GetPageDepartment([FromQuery] GetPageDepartmentReqModel input)
        {
            var result = await _departmentService.GetPageDepartmentAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResModel>> GetDepartmentById(long id)
        {
            var result = await _departmentService.GetDepartmentByIdAsync(TenantId, id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateOrEditDepartmentReqModel input)
        {
            await _departmentService.CreateDepartment(TenantId, input);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(long id, [FromBody] CreateOrEditDepartmentReqModel input)
        {
            await _departmentService.EditDepartment(id, input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }
}
