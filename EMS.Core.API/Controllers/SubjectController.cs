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
        public async Task<ActionResult<SubjectResModel>> GetPageSubject([FromQuery] GetPageSubjectReqModel input)
        {
            var result = await _subjectService.GetPageSubjectAsync(TenantId, input);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInfoSubject(long id)
        {
            var result = await _subjectService.GetInfoSubjectAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] CreateEditSubjectReqModel input)
        {
            await _subjectService.CreateSubjectAsync(TenantId, input);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubject(long id, [FromBody] CreateEditSubjectReqModel input)
        {
            await _subjectService.EditSubjectAsync(TenantId, input);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(long id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return Ok();
        }
    }
}
