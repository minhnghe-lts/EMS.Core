using EMS.Core.Models.Entities;

namespace EMS.Core.Models.ResponseModels
{
    public class GetPageCourseResModel : BasePaginationResModel
    {
        public List<CourseResModel> Data { get; set; }
    }

    public class CourseResModel
    {
        public long Id { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public List<SubjectResModel> Subjects { get; set; }
    }
}
