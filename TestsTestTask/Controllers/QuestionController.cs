using Domain.CreateModels;
using Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TestsTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("AllByTestId")]
        public async Task<ActionResult<List<ViewQuestion>>> GetAllByTestId(int testId)
        {
            return Ok(await _questionService.GetAllByTestId(testId));
        }

        [HttpGet("ByTestIdAndNumber")]
        public async Task<ActionResult<ViewQuestion>> GetByTestIdAndNumber(int testId, int number)
        {
            return Ok(await _questionService.GetByTestIdAndNumber(testId, number));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<int>> AddQuestion(CreateQuestionModel model, int testId)
        {
            return Ok(await _questionService.Add(model, testId));
        }
    }
}
