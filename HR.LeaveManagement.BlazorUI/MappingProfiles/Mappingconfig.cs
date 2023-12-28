using AutoMapper;
using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Models.LeaveAllocations;
using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles
{
	public class Mappingconfig : Profile
	{
		public Mappingconfig()
		{
			CreateMap<LeaveTypeDto, LeaveTypeVM>();
			CreateMap<LeaveTypeVM, CreateLeaveTypeCommand>();
			CreateMap<LeaveTypeVM, UpdateLeaveTypeCommand>();
			CreateMap<LeaveTypeDetailsDto, LeaveTypeVM>();

			CreateMap<LeaveRequestDto, LeaveRequestVM>()
				.ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
				.ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
				.ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
				.ReverseMap();
			CreateMap<LeaveRequestDetailsDto, LeaveRequestVM>()
				.ForMember(q => q.DateRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
				.ForMember(q => q.StartDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
				.ForMember(q => q.EndDate, opt => opt.MapFrom(x => x.EndDate.DateTime))
				.ReverseMap();
			CreateMap<LeaveRequestVM, CreateLeaveRequestCommand>();
			CreateMap<LeaveRequestVM, UpdateLeaveRequestCommand>();

			CreateMap<LeaveAllocationVM,LeaveAllocationDto>().ReverseMap();

			CreateMap<EmployeeVM, Employee>().ReverseMap();
		}
	}
}
