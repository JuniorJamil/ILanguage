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
    public class OutcomeReportServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoOutcomeReportsReturnsEmptyCollection()
        {
            var mockOutcomeReportRepository = GetDefaultIOutcomeReportRepositoryInstance();
            mockOutcomeReportRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<OutcomeReport>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new OutcomeReportService(
                mockOutcomeReportRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<OutcomeReport> result = (List<OutcomeReport>)await service.ListAsync();
            int outcomeReportsCount = result.Count;

            // Assert
            outcomeReportsCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsOutcomeReportNotFoundResponse()
        {
            // Arrange
            var mockOutcomeReportRepository = GetDefaultIOutcomeReportRepositoryInstance();
            var outcomeReportId = 1;
            mockOutcomeReportRepository.Setup(r => r.FindById(outcomeReportId))
                .Returns(Task.FromResult<OutcomeReport>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new OutcomeReportService(mockOutcomeReportRepository.Object, mockUnitOfWork.Object);
            // Act
            OutcomeReportResponse result = await service.GetByIdAsync(outcomeReportId);
            var message = result.Message;
            // Assert
            message.Should().Be("OutcomeReport not found");
        }

        private Mock<IOutcomeReportRepository> GetDefaultIOutcomeReportRepositoryInstance()
        {
            return new Mock<IOutcomeReportRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}