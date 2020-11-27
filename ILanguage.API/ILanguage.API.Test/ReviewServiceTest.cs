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
    public class ReviewServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task ListAsyncWhenNoReviewsReturnsEmptyCollection()
        {
            var mockReviewRepository = GetDefaultIReviewRepositoryInstance();
            mockReviewRepository.Setup(r => r.ListAsync())
                .ReturnsAsync(new List<Review>());
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var service = new ReviewService(
                mockReviewRepository.Object,
                mockUnitOfWork.Object);

            // Act
            List<Review> result = (List<Review>)await service.ListAsync();
            int reviewsCount = result.Count;

            // Assert
            reviewsCount.Should().Equals(0);
        }

        private Mock<IReviewRepository> GetDefaultIReviewRepositoryInstance()
        {
            return new Mock<IReviewRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}