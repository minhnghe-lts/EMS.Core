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
    public class ContractTypeController : BaseController
    {
        private readonly IContractTypeService _contractTypeService;
        public ContractTypeController(IContractTypeService contractTypeService, IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
            _contractTypeService = contractTypeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPageContractType([FromQuery] GetPageContractTypeReqModel input)
        {
            var result = await _contractTypeService.GetPageContractTypeAsync(TenantId, input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateContractTypeAsync([FromBody] CreateEditContractTypeReqModel input)
        {
            await _contractTypeService.CreateContractTypeAsync(TenantId, input);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditContractTypeAsync(long id, [FromBody] CreateEditContractTypeReqModel input)
        {
            await _contractTypeService.EditContractTypeAsync(id, input);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContractTypeAsync(long id)
        {
            await _contractTypeService.DeleteContractTypeAsync(id);
            return Ok();
        }
        [HttpGet("{contractTypeId}")]
        public async Task<ActionResult> GetContracTypeByIdAsync(long contractTypeId)
        {
            var result = await _contractTypeService.GetContracTypeByIdAsync(contractTypeId);
            return Ok(result);
        }

    }
}
