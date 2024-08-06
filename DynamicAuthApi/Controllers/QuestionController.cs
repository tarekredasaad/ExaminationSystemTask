using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService QuestionService;

        public QuestionController(IQuestionService questionService)
        {
            QuestionService = questionService;
        }

        [HttpPost]
        public ActionResult<ResultDTO> Create(QuestionDTO questionDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(QuestionService.AddQuestion(questionDTO));
        }

        [HttpPost("AddExistQuestionToExams")]
        public ActionResult<ResultDTO> AddExistQuestionToExams(ExistQuestionDTO questionDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(QuestionService.AddExistQuestionToExams(questionDTO));
        }

        [HttpPut]
        public ActionResult<ResultDTO> Update(UpdateQuestionDTO questionDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(QuestionService.UpdateQuestion(questionDTO));
        }

    }
}
