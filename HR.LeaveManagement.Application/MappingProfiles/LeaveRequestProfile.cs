using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveRequestProfile:Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
            CreateMap<LeaveRequest, Features.LeaveRequest.Queries.GetLeaveRequests.LeaveRequestDto>();
            CreateMap<LeaveRequest, Features.LeaveRequest.Queries.GetLeaveRequestsByUserId.LeaveRequestDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>().AfterMap((src,des)=>{
                des.Id = Guid.NewGuid().ToString();
            });
        }
    }
}
