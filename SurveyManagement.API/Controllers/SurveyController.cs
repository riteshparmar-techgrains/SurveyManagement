using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Interfaces;
using SurveyManagement.Application.UseCases;

namespace SurveyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _service;
        private readonly CreateSurveyUseCase _createSurveyUseCase;
        public SurveyController(ISurveyService service, CreateSurveyUseCase createSurveyUseCase)
        {
            _service = service;
            _createSurveyUseCase = createSurveyUseCase;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyDto dto)
        {
            await _service.CreateSurveyAsync(dto);
            return Ok();
        }

        [HttpPost("CreateSurveyWithEmail")]
        public async Task<IActionResult> CreateSurveyEmail([FromBody] CreateSurveyDto dto)
        {
            await _createSurveyUseCase.ExecuteAsync(dto.Title,dto.UserEmail);
            return Ok(new { message = "Survey created successfully (mocked)" });
        }

        [HttpPost("GetSurveys")]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _service.GetSurveysAsync();
            return Ok(surveys);
        }        
    }
}
