using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<ResultDTO> RegisterAsyncInstructor(InstructorDTO dto);
        public Task<ResultDTO> LoginAsyncInstructor(InstructorDTO dto);
        //Task<ResultDTO> Logout();

        public Task<ResultDTO> RegisterAsyncStudent(StudentDTO dto);
        public Task<ResultDTO> LoginAsyncStudent(StudentDTO dto);
    }
}
