using Microsoft.EntityFrameworkCore;
using SurveyManagement.Domain.Entities;
using SurveyManagement.Domain.Interfaces;
using SurveyManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Infrastructure.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly AppDbContext _context;
        public SurveyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey?> GetByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }
    }
}
