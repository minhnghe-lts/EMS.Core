namespace EMS.Core.Models.ResponseModels
{
    public class CourseResModel
    {
        public long Id { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public List<SubjectResModel> Subjects { get; set; }
    }
}
