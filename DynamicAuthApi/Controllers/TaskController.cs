using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskServices;
        public TaskController(ITaskService taskServices)
        {
            this.taskServices = taskServices;
        }

        [HttpPost]
        public ActionResult<ResultDTO> Create(TaskDTO taskDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(taskServices.AddTask(taskDTO));
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetByid(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(taskServices.GetTaskById(id));
        }

        [HttpGet("GetTasks")]
        public ActionResult<ResultDTO> GetTasks()
        {
           // if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(taskServices.GetTasks());
        }
        [HttpPut]
        public ActionResult<ResultDTO> UpdateTasks(int id,TaskDTO task)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(taskServices.UpdateTask(id,   task));
        }

        [HttpDelete]
        public ActionResult<ResultDTO> DeleteTask(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(taskServices.DeleteTask(id));
        }
    }
}
