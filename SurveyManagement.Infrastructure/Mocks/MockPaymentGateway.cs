using SurveyManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Infrastructure.Mocks
{
    public class MockPaymentGateway : IPaymentGateway
    {
        public Task<bool> ProcessPaymentAsync(string userId, decimal amount)
        {
            Console.WriteLine($"[MOCK PAYMENT] User: {userId}, Amount: {amount}");
            return Task.FromResult(true); // Always succeed
        }
    }
}
