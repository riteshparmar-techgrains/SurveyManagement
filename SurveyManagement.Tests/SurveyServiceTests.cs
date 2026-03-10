using Moq;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Interfaces;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Tests
{
    public class SurveyServiceTests
    {

        [Fact]
        public async Task CreateSurvey_Should_AddSurvey()
        {
            // Arrange
            var mockRepo = new Mock<ISurveyRepository>();

            var service = new SurveyService(mockRepo.Object);

            // Act
            var dto = new CreateSurveyDto
            {
                Title = "Test Survey"
            };

            // Assert
            await service.CreateSurveyAsync(dto);
            mockRepo.Verify(x => x.AddAsync(It.IsAny<Survey>()), Times.Once);
        }

        //[Fact]
        //public async Task GetSurveys_Should_ReturnAllSurveys()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<ISurveyRepository>();
        //    mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Survey>
        //    {
        //        new Survey { Id = 1, Title = "Survey 1" },
        //        new Survey { Id = 2, Title = "Survey 2" }
        //    });
        //    var service = new SurveyService(mockRepo.Object);
        //    // Act
        //    var surveys = await service.GetSurveysAsync();
        //    // Assert
        //    Assert.Equal(2, surveys.Count);
        //    Assert.Equal("Survey 1", surveys[0].Title);
        //    Assert.Equal("Survey 2", surveys[1].Title);
        //}

        [Fact]
        public async Task CreateSurvey_Should_ThrowException_When_TitleIsEmpty()
        {
            // Arrange
            var mockRepo = new Mock<ISurveyRepository>();
            var service = new SurveyService(mockRepo.Object);
            var dto = new CreateSurveyDto
            {
                Title = ""
            };
            // Act & Assert
            await Assert.ThrowsAsync<AggregateException>(() => service.CreateSurveyAsync(dto));
        }

        [Fact]
        public async Task CreateSurvey_Should_ThrowException_When_TitleIsNull()
        {
            // Arrange
            var mockRepo = new Mock<ISurveyRepository>();
            var service = new SurveyService(mockRepo.Object);
            var dto = new CreateSurveyDto
            {
                Title = null
            };
            // Act & Assert
            await Assert.ThrowsAsync<AggregateException>(() => service.CreateSurveyAsync(dto));
        }

        [Fact]
        public async Task CreateSurvey_Should_ThrowException_When_TitleIsWhitespace()
        {
            // Arrange
            var mockRepo = new Mock<ISurveyRepository>();
            var service = new SurveyService(mockRepo.Object);
            var dto = new CreateSurveyDto
            {
                Title = "   "
            };
            // Act & Assert
            await Assert.ThrowsAsync<AggregateException>(() => service.CreateSurveyAsync(dto));
        }

        [Fact]
        public async Task CreateSurvey_Should_AddSurvey_WithValidTitle()
        {
            // Arrange
            var mockRepo = new Mock<ISurveyRepository>();
            var service = new SurveyService(mockRepo.Object);
            var dto = new CreateSurveyDto
            {
                Title = "Valid Survey Title"
            };
            // Act
            await service.CreateSurveyAsync(dto);
            // Assert
            mockRepo.Verify(x => x.AddAsync(It.Is<Survey>(s => s.Title == "Valid Survey Title")), Times.Once);
        }
    }
}
