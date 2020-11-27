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
    public class ResourceServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoResourcesReturnsEmptyCollection()
        {
            var mockResourceRepository = GetDefaultIResourceRepositoryInstance();
            mockResourceRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Resource>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ResourceService(
                mockResourceRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Resource> result = (List<Resource>)await service.ListAsync();
            int resourcesCount = result.Count;

            // Assert
            resourcesCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsResourceNotFoundResponse()
        {
            // Arrange
            var mockResourceRepository = GetDefaultIResourceRepositoryInstance();
            var resourceId = 1;
            mockResourceRepository.Setup(r => r.FindById(resourceId))
                .Returns(Task.FromResult<Resource>(null));
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ResourceService(mockResourceRepository.Object, mockUnitOfWork.Object);
            // Act
            ResourceResponse result = await service.GetByIdAsync(resourceId);
            var message = result.Message;
            // Assert
            message.Should().Be("Resource not found");
        }

        private Mock<IResourceRepository> GetDefaultIResourceRepositoryInstance()
        {
            return new Mock<IResourceRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}