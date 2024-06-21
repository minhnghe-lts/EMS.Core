using EMS.Core.Commons;

namespace EMS.Core.Models.Entities
{
    public class Subject : BaseEntityWithTenantSoftDeletable
    {
        public string CodeName { get; set; }
        public string Name { get; set; }
        public int TotalExercise { get; set; }
        public virtual ICollection<CourseSubject> CourseSubjects { get; set; }

    }
}
