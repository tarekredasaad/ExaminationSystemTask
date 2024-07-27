using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IAuthService authService;
        public InstructorController( IAuthService authService) 
        {
            this.authService = authService;
        }

        [HttpPost("RegisterInstructor")]
        public ActionResult<ResultDTO> Register(InstructorDTO InsDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            return Ok(authService.RegisterAsyncInstructor(InsDTO));
        }
        [HttpPost("LoginInstructor")]

        public ActionResult<ResultDTO> Login(InstructorDTO InsDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };

            return Ok(authService.LoginAsyncInstructor(InsDTO));
        }
    }
}
