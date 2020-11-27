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
    public class ComplaintServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoComplaintsReturnsEmptyCollection()
        {
            var mockComplaintRepository = GetDefaultIComplaintRepositoryInstance();
            mockComplaintRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Complaint>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ComplaintService(
                mockComplaintRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Complaint> result = (List<Complaint>)await service.ListAsync();
            int complaintsCount = result.Count;

            // Assert
            complaintsCount.Should().Equals(0);
        }


        private Mock<IComplaintRepository> GetDefaultIComplaintRepositoryInstance()
        {
            return new Mock<IComplaintRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}