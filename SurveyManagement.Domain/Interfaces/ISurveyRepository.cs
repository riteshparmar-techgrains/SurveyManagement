using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Domain.Interfaces
{
    public interface ISurveyRepository
    {
        Task AddAsync(Survey survey);
        Task<Survey?> GetByIdAsync(int id);
        Task<IEnumerable<Survey>> GetAllAsync();
    }
}
