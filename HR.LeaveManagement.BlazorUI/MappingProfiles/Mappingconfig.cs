using AutoMapper;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles
{
    public class Mappingconfig:Profile
    {
        public Mappingconfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>();
            CreateMap<LeaveTypeVM, CreateLeaveTypeCommand>();
            CreateMap<LeaveTypeVM, UpdateLeaveTypeCommand>();
        }
    }
}
