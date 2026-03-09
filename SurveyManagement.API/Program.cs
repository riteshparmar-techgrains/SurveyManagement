using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Interfaces;
using SurveyManagement.Domain.Interfaces;
using SurveyManagement.Infrastructure.Data;
using SurveyManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();
builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
