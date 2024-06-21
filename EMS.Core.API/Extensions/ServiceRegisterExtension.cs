using EMS.Core.Business;
using EMS.Core.Business.Implements;
using EMS.Core.Business.Interfaces;

namespace EMS.Core.API.Extensions
{
    public static class ServiceRegisterExtension
    {
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IContractTypeService, ContractTypeService>();
            services.AddTransient<IAccountInfoService, AccountInfoService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IDepartmentLevelService, DepartmentLevelService>();
        }
    }
}
