using EMS.Core.API.Extensions;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using EMS.Core.Models.ResponseModels.ContractType;
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
        public async Task<ActionResult<GetPageContractTypeResModel>> GetPageContractType([FromQuery] GetPageContractTypeReqModel input)
        {
            var result = await _contractTypeService.GetPageContractTypeAsync(TenantId, input);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CreateContractTypeAsync([FromQuery] CreateEditContractTypeReqModel input)
        {
            return Ok(await _contractTypeService.CreateContractTypeAsync(TenantId, input));
        }
        [HttpPut]
        public async Task<ActionResult> EditContractTypeAsync([FromQuery] CreateEditContractTypeReqModel input)
        {
            return Ok(await _contractTypeService.EditContractTypeAsync(input));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteContractTypeAsync([FromQuery]DeleteContractTypeReqModel input)
        {
            return Ok(await _contractTypeService.DeleteContractTypeAsync(input));
        }
        [HttpGet]
        public async Task<ActionResult> GetContracTypeByIdAsync(long contractTypeId)
        {
            return Ok(await _contractTypeService.GetContracTypeByIdAsync(contractTypeId));
        }

    }
}
