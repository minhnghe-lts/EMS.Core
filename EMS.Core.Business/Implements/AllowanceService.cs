using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.Entities;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using EMS.Core.Models.ResponseModels.ContractAllowance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Business.Implements
{
    public class AllowanceService : IAllowanceService
    {
        private readonly AppDbContext _context;

        public AllowanceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateEditAllowanceResModel> CreateAllowanceAsync(long tenantId, CreateEditAllowanceReqModel input)
        {
            try
            {
                var allowance = new Allowance
                {
                    Name = input.Name,
                    TenantId = tenantId,
                    Amount = input.Amount,
                    Description = input.Decription,
                    FromDate = input.FromDate,
                    ToDate = input.ToDate,
                    IsDeleted = false,
                };
                _context.Allowances.Add(allowance);
                await _context.SaveChangesAsync();
                return new CreateEditAllowanceResModel
                {
                    Name = allowance.Name,
                    Amount = allowance.Amount,
                    Decription = allowance.Description,
                    FromDate = allowance.FromDate,
                    ToDate = allowance.ToDate,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DeleteAllowanceResModel> DeleteAllowanceAsync(DeleteAllowanceReqModel input)
        {
            try
            {
                var allowance = _context.Allowances.FirstOrDefault(record => record.Id == input.Id);
                if(allowance == null)
                {
                    throw new ItemNotFoundException();
                }
                allowance.IsDeleted = true;
                _context.Allowances.Update(allowance);
                await _context.SaveChangesAsync();
                return new DeleteAllowanceResModel
                {
                    Id = allowance.Id,
                    IsDeleted = allowance.IsDeleted,
                };
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public async Task<CreateEditAllowanceResModel> EditAllowanceAsync(CreateEditAllowanceReqModel input)
        {
            try
            {
                var allowance = _context.Allowances.FirstOrDefault(record => record.Id == input.Id);
                if(allowance == null)
                {
                    throw new ItemNotFoundException();
                }
                allowance.Amount = input.Amount;
                allowance.Description = input.Decription;
                allowance.FromDate = input.FromDate;
                allowance.ToDate = input.ToDate;
                allowance.Name = input.Name;
                _context.Allowances.Update(allowance);
                await _context.SaveChangesAsync();
                return new CreateEditAllowanceResModel
                {
                    Id = allowance.Id,
                    Name = allowance.Name,
                    Amount = allowance.Amount,
                    Decription = allowance.Description,
                    FromDate = allowance.FromDate,
                    ToDate = allowance.ToDate,
                };
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task<GetPageAllowanceResModel> GetPageAllowanceAsync(long tenantId, GetPageAllowanceReqModel input)
        {
            try
            {
                var query = _context.Allowances.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(record => record.Name);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);
                var data = query.Select(record => new AllowanceResModel {
                    Id = record.Id,
                    Name = record.Name,
                    Amount = record.Amount,
                    Decription = record.Description,
                    FromDate = record.FromDate,
                    ToDate = record.ToDate,
                }).ToList();
                var result = new GetPageAllowanceResModel
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

        public async Task<GetAllowanceResModel> GetAllowanceByIdAsync(long allowanceId)
        {
            try
            {
                var allowance = _context.Allowances.FirstOrDefault(record => record.Id == allowanceId);
                if(allowance == null)
                {
                    throw new ItemNotFoundException();
                }
                return new GetAllowanceResModel
                {
                    Id = allowance.Id,
                    Name = allowance.Name,
                    Amount = allowance.Amount,
                    Decription = allowance.Description,
                    FromDate = allowance.FromDate,
                    ToDate = allowance.ToDate,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
