using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Commands
{
    public  class UpdateLeaveTypeCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly Mock<IAppLogger<UpdateLeaveTypeCommandHandler>> _mockLogger;
        public UpdateLeaveTypeCommandHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepository.InitialLeaveTypeMockRepository();
            _mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            }).CreateMapper();
            _mockLogger = new Mock<IAppLogger<UpdateLeaveTypeCommandHandler>>();
        }

        [Fact]
        public async Task UpdateLeaveType()
        {
            var handler = new UpdateLeaveTypeCommandHandler(_mapper, _mockRepo.Object, _mockLogger.Object);
            var leaveType = new UpdateLeaveTypeCommand
            {
                Id = "b80194ce-25f3-41ed-900f-2bfa801e2a81",
                Name = "Test Anually",
                DefaultDays = 20,
            };
            await handler.Handle(leaveType, CancellationToken.None);
            MockLeaveTypeRepository.mockDb.Any(c => c.Name == leaveType.Name && c.DefaultDays == leaveType.DefaultDays).ShouldBeTrue();
        }
    }
}
