using EMS.Core.Commons;

namespace EMS.Core.Models.Entities
{
    public class Subject : BaseEntityWithTenantSoftDeletable
    {
        public string Name { get; set; }
    }
}
