using SurveyManagement.Application.DTOs;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Application.Interfaces
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task CreateSurveyAsync(CreateSurveyDto dto)
        {
            var survey = new Survey(dto.Title);
            await _surveyRepository.AddAsync(survey);
        }

        public async Task<IEnumerable<Survey>> GetSurveysAsync()
        {
            return await _surveyRepository.GetAllAsync();
        }
    }
}
