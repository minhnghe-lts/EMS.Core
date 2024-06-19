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
        public async Task<ActionResult<GetPageCourseResModel>> GetPageCourse([FromQuery] GetPageCourseReqModel input)
        {
            var result = await _courseService.GetPageCourseAsync(TenantId, input);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromQuery] CreateEditCourseReqModel input)
        {
            await _courseService.CreateCourseAsync(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCourse([FromQuery] CreateEditCourseReqModel input)
        {
            await _courseService.EditCourseAsync(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> DeleteCourse([FromQuery] DeleteCourseReqModel input)
        {
            await _courseService.DeleteCourseAsync(TenantId, input);
            return Ok();
        }
    }
}
