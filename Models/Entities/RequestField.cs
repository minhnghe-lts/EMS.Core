using EMS.Core.Commons;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Models
{
    public class RequestField : BaseEntityWithTenantSoftDeletable
    {
        public long RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public string Name { get; set; }
        public RequestFieldType Type { get; set; }
        public bool IsRequired { get; set; }
    }
}
