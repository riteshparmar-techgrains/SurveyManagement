using Microsoft.EntityFrameworkCore;
using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // DbSet properties for your entities go here

       public DbSet<Survey> Surveys { get; set; }
    }
}
