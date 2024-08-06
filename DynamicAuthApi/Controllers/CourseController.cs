using Domain.DTO;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService courseService;
        public CourseController(ICourseService courseService) 
        {
            this.courseService = courseService;
        }
        [HttpPost]
        public ActionResult<ResultDTO> Create(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
                 return Ok(courseService.AddCourse(courseDTO));
        }

        [HttpPut]
        public ActionResult<ResultDTO> Update(UpdateCourseDTO courseDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(courseService.UpdateCourse(courseDTO));
        }
        [HttpGet("GetCourses")]
        public ActionResult<ResultDTO> GetCourses()
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(courseService.GetCourses());
        }
        [HttpPost("EnrollCourse")]
        public ActionResult<ResultDTO> EnrollCourse(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(courseService.enrollCourse(courseDTO));
        }
    }
}
