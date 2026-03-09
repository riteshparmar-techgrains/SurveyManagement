using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyManagement.Application.DTOs;
using SurveyManagement.Application.Interfaces;

namespace SurveyManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _service;
        public SurveyController(ISurveyService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyDto dto)
        {
            await _service.CreateSurveyAsync(dto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _service.GetSurveysAsync();
            return Ok(surveys);
        }        
    }
}
