using EMS.Core.Commons;

namespace EMS.Core.Models
{
    public class RequestApprovalWorkflow : BaseEntityWithTenantSoftDeletable
    {
        public long RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int StepOrder { get; set; }
        public bool IsAllowPending { get; set; }
    }
}
