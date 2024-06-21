using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
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

        public async Task<GetPageContractResModel> GetPageContractAsync(long tenantId, BasePaginationReqModel input)
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

                var result = new GetPageContractResModel
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

        public async Task CreateContract(CreateOrEditContractReqModel input)
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

                    ContractBenefits = input.BenefitIds.Select(item => new ContractBenefit
                    {
                        BenefitId = item,
                    }).ToList(),
                    ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(item => new ContractRemunerationRegime
                    {
                        RemunerationRegimeId = item,
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

        public async Task EditContract(CreateOrEditContractReqModel input)
        {
            try
            {
                var contract = _context.Contracts
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();

                if(contract == null)
                {
                    throw new ItemNotFoundException();
                }

                contract.ContractTypeId = input.ContractTypeId;
                contract.DepartmentId = input.DepartmentId;
                contract.EmployeeId = input.EmployeeId;
                contract.ExpireDate = input.ExpireDate;
                contract.PositionId = input.PositionId;
                contract.SignedDate = input.SignedDate;

                var contractBenefits = _context.ContractBenefits.Where(record => record.ContractId == input.Id).AsEnumerable();
                _context.ContractBenefits.RemoveRange(contractBenefits);

                contract.ContractBenefits = input.BenefitIds.Select(item => new ContractBenefit
                {
                    BenefitId = item,
                }).ToList();

                var contractRemunerationRegimes = _context.ContractRemunerationRegimes.Where(record => record.ContractId == input.Id).AsEnumerable();
                _context.ContractRemunerationRegimes.RemoveRange(contractRemunerationRegimes);

                contract.ContractRemunerationRegimes = input.RemunerationRegimeIds.Select(item => new ContractRemunerationRegime
                {
                    RemunerationRegimeId = item,
                }).ToList();

                var currentContractAllowances = _context.ContractAllowances.Where(record => record.ContractId == input.Id).ToList();

                foreach (var item in input.ContractAllowances)
                {
                    ContractAllowance newAllowance;
                    if (item.Id <= 0)
                    {
                        newAllowance = new ContractAllowance
                        {
                            ContractId = item.Id,
                            Amount = item.Amount,
                            Description = item.Description,
                            FromDate = item.FromDate,
                            ToDate = item.ToDate,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1,
                        };
                        _context.ContractAllowances.Add(newAllowance);
                    }
                    else
                    {
                        var allowance = currentContractAllowances.Where(c => c.Id == item.Id).FirstOrDefault();
                        if (item.Amount != allowance.Amount || item.FromDate != allowance.FromDate || item.ToDate != allowance.ToDate || item.Description != allowance.Description)
                        {
                            allowance.IsActive = false;
                            allowance.UpdatedAt = DateTime.Now;
                            allowance.UpdatedBy = 1;
                            _context.ContractAllowances.Update(allowance);

                            newAllowance = new ContractAllowance
                            {
                                ContractId = input.Id,
                                Amount = item.Amount,
                                Description = item.Description,
                                FromDate = item.FromDate,
                                ToDate = item.ToDate,
                                CreatedAt = DateTime.Now,
                                CreatedBy = 1,
                            };
                            _context.ContractAllowances.Add(newAllowance);
                        }
                    }
                                       
                }
                var allowanceIds = input.ContractAllowances.Select(item => item.Id).ToHashSet();
                var deletedAllowances = currentContractAllowances.Where(item => !allowanceIds.Contains(item.Id)).ToList();

                foreach (var item in deletedAllowances)
                {
                    item.IsDeleted = true;
                    item.UpdatedBy = 1;
                    item.UpdatedAt = DateTime.Now;
                    _context.ContractAllowances.Update(item);
                }
                _context.Contracts.Update(contract);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteContract(long id)
        {
            try
            {
                var existingContract = _context.Contracts.GetAvailableById(id);
                if(existingContract == null) {
                    throw new ItemNotFoundException();
                }
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
