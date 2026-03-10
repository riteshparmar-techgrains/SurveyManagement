using SurveyManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Infrastructure.Mocks
{
    public class MockEmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            Console.WriteLine($"[MOCK EMAIL] To: {to}, Subject: {subject}, Body: {body}");
            return Task.CompletedTask;
        }
    }
}
