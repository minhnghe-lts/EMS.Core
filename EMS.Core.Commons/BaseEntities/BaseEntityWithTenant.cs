namespace EMS.Core.Commons
{
    public class BaseEntityWithTenant : BaseEntity
    {
        public long TenantId { get; set; }
    }
}
