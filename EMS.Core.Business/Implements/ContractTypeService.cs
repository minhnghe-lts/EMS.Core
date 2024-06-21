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

        public async Task CreateContractTypeAsync(long tenatId, CreateEditContractTypeReqModel input)
        {
            try
            {
                var contractType = new ContractType
                {
                    IsDeleted = false,
                    Name = input.Name,
                    TenantId = tenatId,
                };
                _context.ContractTypes.Add(contractType);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteContractTypeAsync(long contractTypeId)
        {
            try
            {
                var contracType = _context.ContractTypes.GetAvailableById(contractTypeId);
                contracType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditContractTypeAsync(long id, CreateEditContractTypeReqModel input)
        {
            try
            {
                var contractType = _context.ContractTypes.GetAvailableById(id);
                contractType.Name = input.Name;
                _context.ContractTypes.Update(contractType);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContractTypeResModel> GetContracTypeByIdAsync(long contractTypeId)
        {
            try
            {
                var contractType = _context.ContractTypes.GetAvailableById(contractTypeId);
                var resulst = new ContractTypeResModel
                {
                    Id = contractType.Id,
                    Name = contractType.Name,
                };
                return resulst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BasePaginationResModel<ContractTypeResModel>> GetPageContractTypeAsync(long tenantId, BasePaginationReqModel input)
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

                var result = new BasePaginationResModel<ContractTypeResModel>
                {
                    Data = data,
                    TotalItems = totalItems,
                    PageNo = input.PageNo,
                    PageSize = input.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)totalItems / input.PageSize)
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
