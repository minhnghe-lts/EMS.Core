using EMS.Core.API.Extensions;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route(CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<ActionResult<CourseResModel>> GetPageCourse([FromQuery] GetPageCourseReqModel input)
        {
            var result = await _courseService.GetPageCourseAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInfoCourse(long id)
        {
            var result = await _courseService.GetInfoCourseAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateEditCourseReqModel input)
        {
            await _courseService.CreateCourseAsync(TenantId, input);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(long id, [FromBody] CreateEditCourseReqModel input)
        {
            await _courseService.EditCourseAsync(id, input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            await _courseService.DeleteCourseAsync(id);
            return Ok();
        }
    }
}
