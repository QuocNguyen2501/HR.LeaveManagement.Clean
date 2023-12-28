using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveAllocationProfile:Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ForMember(des => des.LeaveType,opt => opt.MapFrom(src=>src.LeaveType.Name));
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>().ForMember(des => des.LeaveType, opt => opt.MapFrom(src => src.LeaveType.Name));
        }
    }
}
