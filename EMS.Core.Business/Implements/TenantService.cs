using EMS.Core.Business.Interfaces;
using EMS.Core.Models;

namespace EMS.Core.Business.Implements
{
    public class TenantService : ITenantService
    {
        private readonly AppDbContext _context;

        public TenantService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTenant()
        {
            try
            {
                _context.Tenants.Add(new Tenant
                {
                    Address = "Admin Tenant Address",
                    FullName = "Administrator",
                    IsActive = true,
                    IsDeleted = false,
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
