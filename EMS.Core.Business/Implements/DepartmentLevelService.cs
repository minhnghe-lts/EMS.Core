using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Implements
{
    public class DepartmentLevelService : IDepartmentLevelService
    {
        private readonly AppDbContext _context;
        public DepartmentLevelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePaginationResModel<DepartmentLevelResModel>> GetPageDepartmentLevel(long tenantId, GetPageDepartmentLevelReqModel input)
        {
            try
            {
                var query = _context.DepartmentLevels.GetAvailableByTenantIdQueryable(tenantId);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new DepartmentLevelResModel
                {
                    Id = record.Id,
                    Name = record.Name,
                    Level = record.Level,
                }).ToList();

                var result = new BasePaginationResModel<DepartmentLevelResModel>
                {
                    Data = data,
                    TotalItems = totalItems,
                    PageNo = input.PageNo,
                    PageSize = input.PageSize,
                    TotalPages = (int)(Math.Ceiling((decimal)totalItems / input.PageSize))
                };
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DepartmentLevelResModel> GetDepartmentLevelByIdAsync(long tenantId, long id)
        {
            try
            {
                var departmentLevel = _context.DepartmentLevels
                    .GetAvailableByTenantIdQueryable(tenantId)
                    .Where(record => record.Id == id)
                    .FirstOrDefault();

                var data = new DepartmentLevelResModel
                {
                    Id = departmentLevel.Id,
                    Name = departmentLevel.Name,
                    Level = departmentLevel.Level,
                };
                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateDepartmentLevel(long tenantId, CreateOrEditDepartmentLevelReqModel input)
        {
            try
            {
                var newDepartmentLevel = new DepartmentLevel
                {
                    Name = input.Name,
                    Level = input.Level,
                    TenantId = tenantId,
                };

                _context.DepartmentLevels.Add(newDepartmentLevel);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditDepartmentLevel(long id, CreateOrEditDepartmentLevelReqModel input)
        {
            try
            {
                var departmentLevel = _context.DepartmentLevels
                    .Where(record => record.Id == id && !record.IsDeleted)
                    .FirstOrDefault();

                if(departmentLevel == null)
                {
                    throw new ItemNotFoundException();
                }
                
                departmentLevel.Name = input.Name;
                departmentLevel.Level = input.Level;

                _context.DepartmentLevels.Update(departmentLevel);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteDepartmentLevel(long id)
        {
            try
            {
                var existingDepartmentLevel = _context.DepartmentLevels.GetAvailableById(id);

                existingDepartmentLevel.IsDeleted = true;
                _context.DepartmentLevels.Update(existingDepartmentLevel);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
