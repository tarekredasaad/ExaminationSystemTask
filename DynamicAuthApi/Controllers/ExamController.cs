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
        public ExamController(IExamService examService)
        {
            this._examService = examService;
        }

        [HttpPost("AddExam")]
        public ActionResult<ResultDTO> AddExam(AddExamDTO examDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.AddExam(examDTO));
        }

        [HttpPost("TakeExam")]
        public ActionResult<ResultDTO> TakeExam(TakeExamDTO examDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_examService.TakeExam(examDTO));
        }
    }
}
