using EMS.Core.Commons;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Models
{
    public class Request : BaseEntityWithTenantSoftDeletable
    {
        public long RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public RequestStatus Status { get; set; }

    }
}
