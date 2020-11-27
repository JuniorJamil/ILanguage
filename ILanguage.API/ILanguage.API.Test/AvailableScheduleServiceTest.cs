using ILanguage.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ILanguage.API.Domain.Models;
using ILanguage.API.Services;
using ILanguage.API.Domain.Services.Communication;

namespace ILanguage.API.Test
{
    public class AvailableScheduleServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsAvailableScheduleNotFoundResponse()
        {
            // Arrange
            var mockAvailableScheduleRepository = GetDefaultIAvailableScheduleRepositoryInstance();
            var availableScheduleId = 1;
            mockAvailableScheduleRepository.Setup(r => r.FindById(availableScheduleId))
                .Returns(Task.FromResult<AvailableSchedule>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new AvailableScheduleService(mockAvailableScheduleRepository.Object, mockUnitOfWork.Object);
            // Act
            AvailableScheduleResponse result = await service.GetByIdAsync(availableScheduleId);
            var message = result.Message;
            // Assert
            message.Should().Be("AvailableSchedule not found");
        }

        private Mock<IAvailableScheduleRepository> GetDefaultIAvailableScheduleRepositoryInstance()
        {
            return new Mock<IAvailableScheduleRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}