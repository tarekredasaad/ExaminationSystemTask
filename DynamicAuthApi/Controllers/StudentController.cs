using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IAuthService authService;
        public StudentController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("RegisterStudent")]
        public ActionResult<ResultDTO> Register(StudentDTO InsDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            return Ok(authService.RegisterAsyncStudent(InsDTO));
        }
        [HttpPost("LoginStudent")]

        public ActionResult<ResultDTO> Login(StudentDTO InsDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            return Ok(authService.LoginAsyncStudent(InsDTO));
        }
    }
}
