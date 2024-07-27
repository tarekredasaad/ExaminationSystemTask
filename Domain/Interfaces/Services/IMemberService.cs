using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IMemberService
    {
        public Task<ResultDTO> AddMember(MemberDTO memberDTO);
        public Task<ResultDTO> GetMemberById(int id);
        public Task<ResultDTO> UpdateMember(int id, MemberDTO memberDTO);
        public Task<ResultDTO> GetMembers();
        public Task<ResultDTO> DeleteMember(int id);
    }
}
