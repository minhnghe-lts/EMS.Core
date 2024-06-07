namespace EMS.Core.Commons
{
    public class BaseEntityWithTenantSoftDeletable : BaseEntitySoftDeletable
    {
        public long TenantId { get; set; }
    }
}
