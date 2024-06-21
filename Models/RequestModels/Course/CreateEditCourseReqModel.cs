using EMS.Core.Models.Entities;

namespace EMS.Core.Models.RequestModels
{
    public class CreateEditCourseReqModel
    {
        public long Id { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public List<long> SubjectIds { get; set; }
    }
}
