using SurveyManagement.Application.Interfaces;
using SurveyManagement.Domain.Interfaces;
using SurveyManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SurveyManagement.Application.UseCases
{
    public class CreateSurveyUseCase
    {
        private readonly IEmailService _emailService;
        private readonly ISurveyRepository _surveyRepository;

        public CreateSurveyUseCase(IEmailService emailService, ISurveyRepository surveyRepository)
        {
            _emailService = emailService;
            _surveyRepository = surveyRepository;
        }

        public async Task ExecuteAsync(string surveyTitle, string userEmail)
        {
            if (string.IsNullOrWhiteSpace(surveyTitle))
                throw new ArgumentException("Survey title cannot be empty", nameof(surveyTitle));

            // Create domain entity
            var survey = new Survey(surveyTitle.Trim());

            // Persist using repository (infrastructure handles DbContext/save behavior)
            await _surveyRepository.AddAsync(survey);

            // Send notification email if provided
            if (!string.IsNullOrWhiteSpace(userEmail))
            {
                await _emailService.SendEmailAsync(userEmail.Trim(), "Survey Created", $"Your survey '{surveyTitle}' has been created successfully.");
            }
        }
    }
}
