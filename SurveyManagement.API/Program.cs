using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Interfaces;
using SurveyManagement.Application.UseCases;
using SurveyManagement.Domain.Interfaces;
using SurveyManagement.Infrastructure.Data;
using SurveyManagement.Infrastructure.Mocks;
using SurveyManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Database Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>(); // ⭐ MISSING LINE
builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.Services.AddScoped<IEmailService, MockEmailService>();
builder.Services.AddScoped<IPaymentGateway, MockPaymentGateway>();

builder.Services.AddScoped<CreateSurveyUseCase>();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Survey Management API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();