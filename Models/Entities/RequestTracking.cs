using EMS.Core.Commons;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Models
{
    public class RequestTracking : BaseEntity
    {
        public long RequestId { get; set; }
        public virtual Request Request { get; set; }
        public long RequestApprovalWorkflowId { get; set; }
        public virtual RequestApprovalWorkflow RequestApprovalWorkflow { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RequestStatus CurrentStatus { get; set; }
        public RequestStatus NewStatus { get; set; }
    }
}
