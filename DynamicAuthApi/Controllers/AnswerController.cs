using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpPost]
        public ActionResult<ResultDTO> Create(AnswersDTO answersDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(answerService.SubmitExam(answersDTO));

        }
    }
}
