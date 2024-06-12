using EMS.Core.Commons;

namespace EMS.Core.Models.Entities
{
    public class Course : BaseEntityWithTenantSoftDeletable
    {
        public string Name { get; set; }
    }
}
