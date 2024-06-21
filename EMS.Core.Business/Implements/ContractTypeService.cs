using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

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
                    TotalPages = (int)Math.Ceiling((decimal)totalItems / input.PageSize)
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateContract(CreateOrUpdateContractReqModel input)
        {
            try
            {
                var newContract = new Contract
                {
                    ContractTypeId = input.ContractTypeId,
                    DepartmentId = input.DepartmentId,
                    EmployeeId = input.EmployeeId,
                    ExpireDate = DateTime.Now.AddYears(1),
                    IsActive = true,
                    PositionId = input.PositionId,
                    SignedDate = input.SignedDate,
                    ContractAllowances = input.ContractAllowances.Select(item => new ContractAllowance
                    {
                        Amount = item.Amount,
                        Description = item.Description,
                        FromDate = item.FromDate,
                        ToDate = item.ToDate,
                    }).ToList(),
                    ContractBenefits = input.BenefitIds.Select(item => new ContractBenefit
                    {
                        BenefitId = item,
                    }).ToList(),
                    ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(item => new ContractRemunerationRegime
                    {
                        RemunerationRegimeId = item,
                    }).ToList(),
                };
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateContract(CreateOrUpdateContractReqModel input)
        {
            try
            {
                var contract = _context.Contracts.GetAvailableById(input.Id);
                contract.ContractTypeId = input.ContractTypeId;
                contract.DepartmentId = input.DepartmentId;
                contract.EmployeeId = input.EmployeeId;
                contract.ExpireDate = DateTime.Now.AddYears(1);
                contract.IsActive = input.IsActive;
                contract.PositionId = input.PositionId;
                contract.SignedDate = input.SignedDate;

                var oldContractAllowances = _context.ContractAllowances
                    .Where(record => record.ContractId == input.Id)
                    .AsEnumerable();

                _context.ContractAllowances.RemoveRange();

                contract.ContractAllowances = input.ContractAllowances.Select(item => new ContractAllowance
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                }).ToList();
                contract.ContractBenefits = input.BenefitIds.Select(item => new ContractBenefit
                {
                    BenefitId = item,
                }).ToList();

                contract.ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(item => new ContractRemunerationRegime
                {
                    RemunerationRegimeId = item,
                }).ToList();

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
