using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Core.API.Controllers
{
    [ApiController]
    [Route(CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    public class ContractTypeController : BaseController
    {
        private readonly IContractTypeService _contractTypeService;

        public ContractTypeController(IContractTypeService contractTypeService)
        {
            _contractTypeService = contractTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<GetPageContractTypeResModel>> GetPageContractType([FromQuery] GetPageContractTypeReqModel input)
        {
            long.TryParse(HttpContext.Items[CommonConstants.ContextItem.TENANT_ID].ToString(), out var TenantId);
            var result = await _contractTypeService.GetPageContractTypeAsync(TenantId, input);
            return Ok(result);
        }
    }
}
