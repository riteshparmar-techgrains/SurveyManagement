using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Interfaces;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Domain.Interfaces;
using Xunit;

namespace SurveyManagement.Tests
{
    public class SurveyServiceTests
    {
        private static SurveyService CreateService(Mock<ISurveyRepository> repo)
            => new SurveyService(repo.Object);

        [Fact]
        public async Task CreateSurvey_Should_AddSurvey()
        {
            var repo = new Mock<ISurveyRepository>();
            var service = CreateService(repo);

            var dto = new CreateSurveyDto { Title = "Test Survey" };

            await service.CreateSurveyAsync(dto);

            repo.Verify(x => x.AddAsync(It.IsAny<Survey>()), Times.Once);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public async Task CreateSurvey_InvalidTitle_ThrowsArgumentException(string title)
        {
            var repo = new Mock<ISurveyRepository>();
            var service = CreateService(repo);
            var dto = new CreateSurveyDto { Title = title };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateSurveyAsync(dto));
        }

        [Fact]
        public async Task CreateSurvey_WithValidTitle_PersistsSurvey()
        {
            var repo = new Mock<ISurveyRepository>();
            var service = CreateService(repo);
            var dto = new CreateSurveyDto { Title = "Valid Survey Title" };

            await service.CreateSurveyAsync(dto);

            repo.Verify(x => x.AddAsync(It.Is<Survey>(s => s.Title == dto.Title)), Times.Once);
        }

        [Fact]
        public async Task GetSurveys_ReturnsEmpty_WhenNoneExist()
        {
            var repo = new Mock<ISurveyRepository>();
            repo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Survey>());
            var service = CreateService(repo);

            var surveys = await service.GetSurveysAsync();

            Assert.Empty(surveys);
        }

        [Fact]
        public async Task GetSurveys_PropagatesRepositoryException()
        {
            var repo = new Mock<ISurveyRepository>();
            repo.Setup(x => x.GetAllAsync()).ThrowsAsync(new Exception("Database error"));
            var service = CreateService(repo);

            await Assert.ThrowsAsync<Exception>(() => service.GetSurveysAsync());
        }
    }
}
