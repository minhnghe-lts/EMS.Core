using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using EMS.Core.Models.ResponseModels.ContractType;

namespace EMS.Core.Business.Implements
{
    public class ContractTypeService : IContractTypeService
    {
        private readonly AppDbContext _context;

        public ContractTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateEditContractTypeResModel> CreateContractTypeAsync(long tenatId, CreateEditContractTypeReqModel input)
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
                var result = new CreateEditContractTypeResModel
                {
                    ContractTypeName = contractType.Name,
                };
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DeleteContractTypeResModel> DeleteContractTypeAsync(DeleteContractTypeReqModel input)
        {
            try
            {
                var contracType = _context.ContractTypes.FirstOrDefault(record => record.Id == input.Id);
                if (contracType == null)
                {
                    throw new ItemNotFoundException();
                }
                contracType.IsDeleted = true;
                await _context.SaveChangesAsync();
                var result = new DeleteContractTypeResModel
                {
                    Id = contracType.Id,
                    Name = contracType.Name,
                    IsDeleted = contracType.IsDeleted,
                };
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CreateEditContractTypeResModel> EditContractTypeAsync(CreateEditContractTypeReqModel input)
        {
            try
            {
                var contractType = _context.ContractTypes.FirstOrDefault(record => record.Id == input.Id && !record.IsDeleted);
                if (contractType == null)
                {
                    throw new ItemNotFoundException();
                }
                contractType.Name = input.Name;
                _context.ContractTypes.Update(contractType);
                await _context.SaveChangesAsync();
                var result = new CreateEditContractTypeResModel
                {
                    Id = contractType.Id,
                    ContractTypeName = contractType.Name,
                };
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetContractTypeResModel> GetContracTypeByIdAsync(long contractTypeId)
        {
            try
            {
                var contractType = _context.ContractTypes.FirstOrDefault(record => record.Id == contractTypeId);
                if(contractType == null)
                {
                    throw new ItemNotFoundException();
                }
                return new GetContractTypeResModel
                {
                    Id = contractType.Id,
                    Name = contractType.Name,
                };
            }
            catch (Exception)
            {
                throw;
            }
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
