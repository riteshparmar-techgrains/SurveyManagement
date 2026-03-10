using SurveyManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Application.UseCases
{
    public class CreateSurveyUseCase
    {
        private readonly IEmailService _emailService;

        public CreateSurveyUseCase(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task ExecuteAsync(string surveyTitle, string userEmail)
        {
            // Simulate survey creation logic
            Console.WriteLine($"Survey {surveyTitle} created.");

            // Simulate sending a notification email
            await _emailService.SendEmailAsync(userEmail, "Survey Created", $"Your survey '{surveyTitle}' has been created successfully.");
        }
    }
}
