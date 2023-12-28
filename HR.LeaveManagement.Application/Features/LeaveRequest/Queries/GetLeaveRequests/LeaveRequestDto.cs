using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequests
{
    public class LeaveRequestDto
    {
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string RequestingEmployeedId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestComments { get; set; }
        public LeaveRequestStatus Status { get; set; }
    }
}
