using EMS.Core.Business.Interfaces;
using EMS.Core.Commons;
using EMS.Core.Models;
using EMS.Core.Models.Entities;
using EMS.Core.Models.RequestModels;
using EMS.Core.Models.ResponseModels;

namespace EMS.Core.Business.Implements 
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasePaginationResModel<CourseResModel>> GetPageCourseAsync(long tenantId, BasePaginationReqModel input)
        {
            try
            {
                var query = _context.Courses.GetAvailableByTenantIdQueryable(tenantId);
                query = query.OrderBy(record => record.CodeName);
                query = query.ApplyPaging(input.PageNo, input.PageSize, out var totalItems);

                var data = query.Select(record => new CourseResModel
                {
                    Id = record.Id,
                    CodeName = record.CodeName,
                    Name = record.Name,
                    Subjects = record.CourseSubjects.Select(record => new SubjectResModel
                    {
                        Id = record.Subject.Id,
                        Name = record.Subject.Name,
                    }).ToList()
                }).ToList();

                var result = new BasePaginationResModel<CourseResModel>
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

        public async Task<CourseResModel> GetInfoCourseAsync(long courseId)
        {
            try
            {
                var course = _context.Courses
                    .Where(record => record.Id == courseId && !record.IsDeleted)
                    .Select(record => new CourseResModel
                    {
                        Id = record.Id,
                        CodeName = record.CodeName,
                        Name = record.Name,
                        Subjects = record.CourseSubjects.Select(sub => new SubjectResModel
                        {
                            Id = sub.Subject.Id,
                            Name = sub.Subject.Name,
                        }).ToList(),
                    })
                    .FirstOrDefault();
                    return course;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateCourseAsync(long tenantId, CreateEditCourseReqModel input)
        {
            try
            {
                var newCourse = new Course
                {
                    CodeName = input.CodeName,
                    Name = input.Name,
                    CourseSubjects = input.SubjectIds.Select(record=> new CourseSubject
                    {
                        SubjectId = record
                    }).ToList(),
                    TenantId = tenantId,
                };
                _context.Courses.Add(newCourse);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditCourseAsync(long id, CreateEditCourseReqModel input)
        {
            try
            {
                var course = _context.Courses.GetAvailableById(id);
                var courseSubjects = _context.CourseSubjects
                    .Where(record => record.CourseId == course.Id)
                    .ToList();
                course.CodeName = input.CodeName;
                course.Name = input.Name;

                _context.CourseSubjects.RemoveRange(course.CourseSubjects);

                var newCourseSubjects = input.SubjectIds.Select(record => new CourseSubject
                {
                    SubjectId = record,
                }).ToList();
                course.CourseSubjects = newCourseSubjects;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCourseAsync(long id)
        {
            try
            {
                var course = _context.Courses.GetAvailableById(id);
                var courseSubjects = _context.CourseSubjects
                    .Where(record => record.CourseId == course.Id)
                    .ToList();
                course.IsDeleted = true;
                _context.CourseSubjects.RemoveRange(course.CourseSubjects);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
