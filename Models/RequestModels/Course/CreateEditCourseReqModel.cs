using EMS.Core.Models.Entities;

namespace EMS.Core.Models.RequestModels
{
    public class CreateEditCourseReqModel
    {
        public string CodeName { get; set; }
        public string Name { get; set; }
        public List<long> SubjectIds { get; set; }
    }
}
