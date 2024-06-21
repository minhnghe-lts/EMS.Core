using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Business.Implements
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePaginationResModel<DepartmentResModel>> GetPageDepartmentAsync(long tenantId, GetPageDepartmentReqModel input)
        {
            try
            {
                var query = _context.Departments.GetAvailableByTenantIdQueryable(tenantId);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new DepartmentResModel
                {
                    Id = record.Id,
                    Name = record.Name,
                    ParentName = record.Parent.Name,
                    DepartmentLevelName = record.DepartmentLevel.Name,
                }).ToList();

                var result = new BasePaginationResModel<DepartmentResModel>
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

        public async Task<DepartmentResModel> GetDepartmentByIdAsync(long tenantId, long id)
        {
            try
            {
                var department = _context.Departments
                    .GetAvailableByTenantIdQueryable(tenantId)
                    .Where(record => record.Id == id && record.IsActive)
                    .FirstOrDefault();

                var data = new DepartmentResModel
                {
                    Id = department.Id,
                    Name = department.Name,
                    ParentName = department.Parent.Name,    
                    DepartmentLevelName = department.DepartmentLevel.Name,
                };
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateDepartment(long tenantId, CreateOrEditDepartmentReqModel input)
        {
            try
            {
                var newDepartment = new Department
                {
                    Name = input.Name,
                    DepartmentLevelId = input.DepartmentLevelId,
                    ParentId = input.ParentId,
                    IsActive = true,
                    TenantId = tenantId,

                    Positions = input.PositionIds.Select(item => new Position
                    {
                        Id = item
                    }).ToList(),
                    DepartmentManagers = input.DepartmentManagerIds.Select(item => new DepartmentManager
                    {
                        Id = item
                    }).ToList()                   
                };

                _context.Departments.Add(newDepartment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditDepartment(long id, CreateOrEditDepartmentReqModel input)
        {
            try
            {
                var department = _context.Departments
                    .Where(record => record.Id == id && !record.IsDeleted)
                    .FirstOrDefault();

                if(department == null)
                {
                    throw new ItemNotFoundException();
                }

                department.Name = input.Name;   
                department.DepartmentLevelId = input.DepartmentLevelId;
                department.ParentId = input.ParentId;
                
                var positions = _context.Positions.Where(record => record.DepartmentId == id).AsEnumerable();

                _context.Positions.RemoveRange(positions);
                department.Positions = input.PositionIds.Select(itemId => new Position
                {
                    Id = itemId
                }).ToList();

                var departmentManagers = _context.DepartmentManagers.Where(record => record.DepartmentId == id).AsEnumerable();
                _context.DepartmentManagers.RemoveRange(departmentManagers);
                department.DepartmentManagers = input.DepartmentManagerIds.Select(itemId => new DepartmentManager
                {
                    Id = itemId
                }).ToList();

                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteDepartment(long id)
        {
            try
            {
                var existingDepartment = _context.Departments.GetAvailableById(id);

                existingDepartment.IsDeleted = true;
                _context.Departments.Update(existingDepartment);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
