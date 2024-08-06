using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IExamService _examService;
        IEvaluateExamService EvaluateExamService { get; set; }
        public ExamController(IExamService examService, IEvaluateExamService evaluateExamService)
        {
            this._examService = examService;
            EvaluateExamService = evaluateExamService;
        }

        [HttpPost("AddExam")]
        public ActionResult<ResultDTO> AddExam(AddExamDTO examDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.AddExam(examDTO));
        }

        [HttpPost("AddExamBySystem")]
        public ActionResult<ResultDTO> AddExamBySystem()
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.AddExamBySystem());
        }

        [HttpPost("TakeExam")]
        public ActionResult<ResultDTO> TakeExam(TakeExamDTO examDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.TakeExam(examDTO));
        }

        [HttpPost("EvaluateExam")]
        public  ActionResult<ResultDTO> EvaluateExam(EvaluateExamDTO evaluateExamDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(EvaluateExamService.EvaluateExam(evaluateExamDTO));
        }

        [HttpPost("ViewResult")]
        public ActionResult<ResultDTO> ViewResult(ExamResultDTO examResultDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.ViewResult(examResultDTO));
        }
    }
}
