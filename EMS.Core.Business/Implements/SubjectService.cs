using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.Entities;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Core.Business.Implements
{
    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext _context;
        public SubjectService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetPageSubjectResModel> GetPageSubjectAsync(long tenantId, BasePaginationReqModel input)
        {
            try
            {
                var query = _context.Subjects.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(x => x.CodeName);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new SubjectResModel
                {
                    Id = record.Id,
                    CodeName = record.CodeName,
                    Name = record.Name,
                    TotalExercise = record.TotalExercise,
                }).ToList();

                var result = new GetPageSubjectResModel
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

        public async Task<GetInfoSubjectResModel> GetInfoSubjectAsync(long tenantId, GetInfoSubjectReqModel input)
        {
            try
            {
                var subject = _context.Subjects
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();
                return new GetInfoSubjectResModel
                {
                    Id = subject.Id,
                    CodeName = subject.CodeName,
                    Name = subject.Name,
                    TotalExercise = subject.TotalExercise,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateSubjectAsync(long tenantId, CreateEditSubjectReqModel input)
        {
            try
            {
                var newSubject = new Subject
                {
                    CodeName = input.CodeName,
                    Name = input.Name,
                    TotalExercise = input.TotalExercise,
                    TenantId = tenantId,
                };
                _context.Subjects.Add(newSubject);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditSubjectAsync(long tenantId, CreateEditSubjectReqModel input)
        {
            try
            {
                var subject = _context.Subjects
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();
                if (subject == null)
                {
                    throw new ItemNotFoundException();
                }
                subject.CodeName = input.CodeName;
                subject.Name = input.Name;
                subject.TotalExercise = input.TotalExercise;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteSubjectAsync(long tenantId, DeleteSubjectReqModel input)
        {
            try
            {
                var subject = _context.Subjects
                    .Where(record => record.Id == input.Id && !record.IsDeleted)
                    .FirstOrDefault();
                if (subject == null)
                {
                    throw new ItemNotFoundException();
                }
                subject.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
