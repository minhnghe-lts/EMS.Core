using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class RequestFieldValue : BaseEntitySoftDeletable
    {
        public long RequestId { get; set; }
        public virtual Request Request { get; set; }
        public long RequestFieldId { get; set; }
        public virtual RequestField RequestField { get; set; }
        public string Value { get; set; }
    }
}
