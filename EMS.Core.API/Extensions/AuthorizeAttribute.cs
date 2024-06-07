using EMS.Core.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.API.Extensions;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly FeatureCode[] _permissions;

    public AuthorizeAttribute(FeatureCode permission = FeatureCode.Common)
    {
        _permissions = new FeatureCode[] { permission };
    }

    public AuthorizeAttribute(params FeatureCode[] permissions)
    {
        _permissions = permissions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var permissions = (List<FeatureCode>)context.HttpContext.Items[CommonConstants.ContextItem.PERMISSIONS]!;
            if (!permissions.Any(permission => _permissions.Contains(permission)))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

        }
        catch (Exception)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}