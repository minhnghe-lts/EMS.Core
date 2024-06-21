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
    public class PositionService : IPositionService
    {
        private readonly AppDbContext _context;
        public PositionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetPagePositionResModel> GetPagePositonAsync(long tenantId, GetPagePositionReqModel input)
        {
            try
            {
                var query = _context.Positions.GetAvailableByTenantIdQueryable(tenantId);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new PositionResModel
                {
                    Id = record.Id,
                    Name = record.Name,
                    DepartmentName = record.Department.Name,
                }).ToList();

                var result = new GetPagePositionResModel
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

        public async Task<PositionResModel> GetPositionByIdAsync(long tenantId, long id)
        {
            try
            {
                var position = _context.Positions
                    .GetAvailableByTenantIdQueryable(tenantId)
                    .Where(record => record.Id == id && !record.IsDeleted)
                    .FirstOrDefault();

                if (position == null)
                {
                    throw new ItemNotFoundException();
                }

                var data = new PositionResModel
                {
                    Id = position.Id,
                    Name = position.Name,
                    DepartmentName = position.Department.Name,
                };
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreatePosition(long tenantId, CreateOrEditPositionReqModel input)
        {
            try
            {
                var newPosition = new Position
                {
                    Name = input.Name,
                    DepartmentId = input.DepartmentId,
                    TenantId = tenantId,

                    PositionRoles = input.PositionRoleIds.Select(item => new PositionRole
                    {
                        Id = item
                    }).ToList(),

                    PositionPermissions = input.PositionPermissionIds.Select(item => new PositionPermission
                    {
                        Id = item
                    }).ToList()
                };

                _context.Positions.Add(newPosition);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EditPosition(CreateOrEditPositionReqModel input)
        {
            try
            {
                var position = _context.Positions
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();

                if(position == null)
                {
                    throw new ItemNotFoundException();
                }

                position.Name = input.Name;
                position.DepartmentId = input.DepartmentId;
                
                var positionRoles = _context.PositionRoles.Where(record => record.PositionId == input.Id).AsEnumerable();
                _context.PositionRoles.RemoveRange(positionRoles);
                position.PositionRoles = input.PositionRoleIds.Select(item => new PositionRole
                {
                    Id = item
                }).ToList();

                var positionPermissions = _context.PositionPermissions.Where(record => record.PositionId == input.Id).AsEnumerable();
                _context.PositionPermissions.RemoveRange(positionPermissions);
                position.PositionPermissions = input.PositionPermissionIds.Select(item => new PositionPermission
                {
                    Id = item
                }).ToList();

                _context.Positions.Update(position);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeletePosition(long id)
        {
            try
            {
                var existingPosition = _context.Positions.GetAvailableById(id);
                if(existingPosition == null)
                {
                    throw new ItemNotFoundException();
                }
                existingPosition.IsDeleted = true;
                _context.Positions.Update(existingPosition);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
