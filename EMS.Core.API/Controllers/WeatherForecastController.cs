using EMS.Core.API.Extensions;
using EMS.Core.Business;
using EMS.Core.Commons;
using EMS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EMS.Core.API.Controllers
{
    [ApiController]
    [Route(CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAuthService _authService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppSettings _appSettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<AppSettings> appSetting, IAuthService authService)
        {
            _logger = logger;
            _appSettings = appSetting.Value;
            _authService = authService;
        }

        [Authorize(CommonEnums.FeatureCode.Common, CommonEnums.FeatureCode.SystemAdmin)]
        [HttpGet()]
        public IActionResult Get()
        {
            var permission = HttpContext.Items[CommonConstants.ContextItem.PERMISSIONS];
            return Ok(JwtHelper.GenerateToken("mail", new List<CommonEnums.FeatureCode> { CommonEnums.FeatureCode.Common }, _appSettings.Jwt.SecretKey));
        }

        [HttpGet("[action]")]
        public IActionResult GetToken()
        {
            var result = _authService.GenerateToken();
            return Ok(result);
        }
    }
}
