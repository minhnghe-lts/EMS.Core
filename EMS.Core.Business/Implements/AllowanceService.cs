using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.Entities;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
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

        public async Task CreateAllowanceAsync(long tenantId, CreateEditAllowanceReqModel input)
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllowanceAsync(long allowanceId)
        {
            try
            {
                var allowance = _context.Allowances.GetAvailableById(allowanceId);
                allowance.IsDeleted = true;
                _context.Allowances.Update(allowance);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw ;
            }
        }

        public async Task EditAllowanceAsync(long id, CreateEditAllowanceReqModel input)
        {
            try
            {
                var allowance = _context.Allowances.GetAvailableById(id);
                allowance.Amount = input.Amount;
                allowance.Description = input.Decription;
                allowance.FromDate = input.FromDate;
                allowance.ToDate = input.ToDate;
                allowance.Name = input.Name;
                _context.Allowances.Update(allowance);
                await _context.SaveChangesAsync();
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task<BasePaginationResModel<AllowanceResModel>> GetPageAllowanceAsync(long tenantId, GetPageAllowanceReqModel input)
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
                var result = new BasePaginationResModel<AllowanceResModel>
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

        public async Task<AllowanceResModel> GetAllowanceByIdAsync(long allowanceId)
        {
            try
            {
                var allowance = _context.Allowances.GetAvailableById(allowanceId);
                var result = new AllowanceResModel
                {
                    Id = allowance.Id,
                    Name = allowance.Name,
                    Amount = allowance.Amount,
                    Decription = allowance.Description,
                    FromDate = allowance.FromDate,
                    ToDate = allowance.ToDate,
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
