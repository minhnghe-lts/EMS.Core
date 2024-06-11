using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Implements
{
    public class ContractTypeService : IContractTypeService
    {
        private readonly AppDbContext _context;

        public ContractTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetPageContractTypeResModel> GetPageContractTypeAsync(long tenantId, BasePaginationReqModel input)
        {
            try
            {
                var query = _context.ContractTypes.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(record => record.Name);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new ContractTypeResModel
                {
                    Id = record.Id,
                    Name = record.Name,
                }).ToList();

                var result = new GetPageContractTypeResModel
                {
                    Data = data,
                    TotalItems = totalItems,
                    PageNo = input.PageNo,
                    PageSize = input.PageSize,
                    TotalPages = (int)Math.Floor((decimal)totalItems / input.PageSize)
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
