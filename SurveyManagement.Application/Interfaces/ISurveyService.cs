using SurveyManagement.Application.DTOs;
using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Application.Interfaces
{
    public interface ISurveyService
    {
        Task CreateSurveyAsync(CreateSurveyDto dto);
        Task<IEnumerable<Survey>> GetSurveysAsync();
    }
}
