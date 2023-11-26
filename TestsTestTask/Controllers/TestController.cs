using Domain.CreateModels;
using Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TestsTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<ViewTest>>> GetAllTest()
        {
            return Ok(await _testService.GetAllTest());
        }

        [HttpPost("Add")]
        public async Task<ActionResult<int>> AddTest(CreateTestModel model)
        {
            return Ok(await _testService.Add(model));
        }

        [HttpGet("CompleteTest")]
        public async Task<ActionResult<bool>> CompleteTest(int testId, int correctAnswerCount)
        {
            return Ok(await _testService.CompleteTest(testId, correctAnswerCount));
        }

        [HttpGet("IsTestPassed")]
        public async Task<ActionResult<bool>> IsTestPassed(int testId)
        {
            return Ok(await _testService.isTestPassed(testId));
        }

        [HttpGet("IsTestCompleted")]
        public async Task<ActionResult<bool>> IsTestCompleted(int testId)
        {
            return Ok(await _testService.isTestCompleted(testId));
        }
    }
}
