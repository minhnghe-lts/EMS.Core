using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.RequestModels.Contract;
using EMS.Core.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Business.Implements
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _context;

        public ContractService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePaginationResModel<ContractResModel>> GetPageContractAsync(long tenantId, BasePaginationReqModel input)
        {
            try
            {
                var query = _context.Contracts.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new ContractResModel
                {
                    EmployeeName = record.Employee.FirstName + " " + record.Employee.LastName,
                    DepartmentName = record.Department.Name,
                    PositionName = record.Position.Name,
                    ContractType = record.ContractType.Name,
                    ExpireDate = record.ExpireDate,
                    SignedDate = record.SignedDate,
                }).ToList();

                var result = new BasePaginationResModel<ContractResModel>
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

        public async Task CreateContract(long tenantId, CreateOrEditContractReqModel input)
        {
            try
            {
                var newContract = new Contract
                {
                    ContractTypeId = input.ContractTypeId,
                    DepartmentId = input.DepartmentId,
                    EmployeeId = input.EmployeeId,
                    ExpireDate = input.ExpireDate,
                    PositionId = input.PositionId,
                    SignedDate = input.SignedDate,

                    ContractAllowances = input.ContractAllowances
                        .Select(item => new ContractAllowance
                        {
                            Amount = item.Amount,
                            Description = item.Description,
                            FromDate = item.FromDate,
                            ToDate = item.ToDate,
                        }).ToList(),

                    ContractBenefits = input.BenefitIds.Select(itemId => new ContractBenefit
                    {
                        BenefitId = itemId,
                    }).ToList(),
                    ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(itemId => new ContractRemunerationRegime
                    {
                        RemunerationRegimeId = itemId,
                    }).ToList(),
                };
                _context.Contracts.Add(newContract);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditContract(long id, CreateOrEditContractReqModel input)
        {
            try
            {
                var contract = _context.Contracts
                    .Where(record => record.Id == id && !record.IsDeleted)
                    .Include(record => record.ContractAllowances)
                    .Include(record => record.ContractBenefits)
                    .Include(record => record.ContractRemunerationRegimes)
                    .FirstOrDefault();

                if(contract == null)
                {
                    throw new ItemNotFoundException();
                }
             
                _context.ContractAllowances.RemoveRange(contract.ContractAllowances);
                _context.ContractBenefits.RemoveRange(contract.ContractBenefits);
                _context.ContractRemunerationRegimes.RemoveRange(contract.ContractRemunerationRegimes);
                UpdateContractInfo(contract, input);

                _context.Contracts.Update(contract);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateContractInfo(Contract contract, CreateOrEditContractReqModel input)
        {
            contract.ContractTypeId = input.ContractTypeId;
            contract.DepartmentId = input.DepartmentId;
            contract.EmployeeId = input.EmployeeId;
            contract.ExpireDate = input.ExpireDate;
            contract.PositionId = input.PositionId;
            contract.SignedDate = input.SignedDate;

            contract.ContractAllowances = input.ContractAllowances.Select(item => new ContractAllowance
            {
                ContractId = item.Id,
                Amount = item.Amount,
                Description = item.Description,
                FromDate = item.FromDate,
                ToDate = item.ToDate,
            }).ToList();

            contract.ContractBenefits = input.BenefitIds.Select(itemId => new ContractBenefit
            {
                BenefitId = itemId,
            }).ToList();


            contract.ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(itemId => new ContractRemunerationRegime
            {
                RemunerationRegimeId = itemId,
            }).ToList();
        }

        public async Task DeleteContract(long id)
        {
            try
            {
                var existingContract = _context.Contracts.GetAvailableById(id);

                existingContract.IsDeleted = true;
                _context.Contracts.Update(existingContract);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
