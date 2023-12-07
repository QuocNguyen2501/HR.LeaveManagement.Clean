using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommand:IRequest<Unit>
    {
        public string Id { get; set; }
        public int NumberOfDays { get; set; }
        public string LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
