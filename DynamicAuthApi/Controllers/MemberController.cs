using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService; 
        }

        [HttpPost]
        public ActionResult<ResultDTO> Create(MemberDTO memberDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_memberService.AddMember(memberDTO));
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetByid(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_memberService.GetMemberById(id));
        }

        [HttpGet("GetMembers")]
        public ActionResult<ResultDTO> GetMembers()
        {
            // if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_memberService.GetMembers());
        }
        [HttpPut]
        public ActionResult<ResultDTO> UpdateMember(int id, MemberDTO memberDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_memberService.UpdateMember(id, memberDTO));
        }

        [HttpDelete]
        public ActionResult<ResultDTO> DeleteMember(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_memberService.DeleteMember(id));
        }
    }
}
