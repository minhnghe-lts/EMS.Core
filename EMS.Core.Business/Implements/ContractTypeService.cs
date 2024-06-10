using EMS.Core.Commons;
using EMS.Core.Models;

namespace EMS.Core.Business.Implements
{
    public class ContractTypeService
    {
        private readonly AppDbContext _context;

        public ContractTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task GetPagedContractType(long tenantId)
        {
            try
            {
                var query = _context.ContractTypes
                    .GetAvailableByTenantIdQueryable(tenantId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
