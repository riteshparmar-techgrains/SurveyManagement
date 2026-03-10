using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Application.Interfaces
{
    public interface IPaymentGateway
    {
        Task<bool> ProcessPaymentAsync(string userId, decimal amount);
    }
}
