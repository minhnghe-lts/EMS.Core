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
    public class SubjectController : BaseController
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<GetPageSubjectResModel>> GetPageSubject([FromQuery] GetPageSubjectReqModel input)
        {
            var result = await _subjectService.GetPageSubjectAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetInfoSubject([FromQuery] GetInfoSubjectReqModel input)
        {
            return Ok(await _subjectService.GetInfoSubjectAsync(TenantId, input));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromQuery] CreateEditSubjectReqModel input)
        {
            await _subjectService.CreateSubjectAsync(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditSubject([FromQuery] CreateEditSubjectReqModel input)
        {
            await _subjectService.EditSubjectAsync(TenantId, input);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> DeleteSubject([FromQuery] DeleteSubjectReqModel input)
        {
            await _subjectService.DeleteSubjectAsync(TenantId, input);
            return Ok();
        }
    }
}
