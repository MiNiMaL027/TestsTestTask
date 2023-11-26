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
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<ViewAnswer>>> GetAllByQuestion(int questionId)
        {
            return Ok(await _answerService.GetAllByQuestion(questionId));
        }

        [HttpGet("IsCorrectAnswer")]
        public async Task<ActionResult<bool>> IsCorrectAnswer(int answerId)
        {
            return Ok(await _answerService.isCorrectAnswer(answerId));
        }

        [HttpPost("Add")]
        public async Task<ActionResult<int>> Add(CreateAnswerModel model, int questionId)
        {
            return Ok(await _answerService.Add(model, questionId));
        }

        [HttpGet("CorrectAnswerCount")]
        public async Task<ActionResult<int>> GetCorrectAnswerCount([FromQuery]List<int> answerIds)
        {
            return Ok(await _answerService.CountCorrectAnswers(answerIds));
        }
    }
}
