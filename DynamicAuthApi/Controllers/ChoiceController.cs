using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        IChoiceService choiceService;

        public ChoiceController (IChoiceService choiceService)
        {
            this.choiceService = choiceService;
        }

        [HttpPost]
        public ActionResult<ResultDTO> Create(ChoiceDTO choiceDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(choiceService.AddChoice(choiceDTO));
        }

        [HttpPut]
        public ActionResult<ResultDTO> Update(UpdateChoiceDTO choiceDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(choiceService.UpdateChoice(choiceDTO));
        }

    }
}
