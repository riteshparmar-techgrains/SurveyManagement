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
    }
}
