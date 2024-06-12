﻿using EMS.Core.Commons;

namespace EMS.Core.Models.Entities
{
    public class CourseSubject : BaseEntity
    {
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
        public long SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
