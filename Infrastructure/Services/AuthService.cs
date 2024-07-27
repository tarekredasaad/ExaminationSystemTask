using AutoMapper;
using Domain.DTO;
using Domain.Helper;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResultDTO> RegisterAsyncInstructor(InstructorDTO dto)
        {
            Instructor instructor = new Instructor();
            dto.password = HashPassword.Encrypt( dto.password);
            instructor = _mapper.Map<Instructor>(dto);
            _unitOfWork.InstructorRepo.Create(instructor);
            _unitOfWork.commit();
            ResultDTO Result = new ResultDTO()
            {
                StatusCode = 200,
                Data = instructor,
                Message = "You added the Instructor successfully"
            };
            return Result;

            //await _userRepository.AddAsync(user);
        }

        public async Task<ResultDTO> LoginAsyncInstructor(InstructorDTO dto)
        {
            Instructor instructor = _unitOfWork.InstructorRepo.Get(i => i.username == dto.username);
                var password = HashPassword.Decrypt( instructor.password);
            if (instructor == null || password != dto.password)
            {
                return (new ResultDTO() { StatusCode = 400, Data = "invalid username or password" , Message = "invalid username or password" });
            }
          
            //// For simplicity, we are not using tokens here. Instead, set a session or a cookie.
            _httpContextAccessor.HttpContext.Session.SetString("Username", instructor.username);
            return (new ResultDTO() { StatusCode = 200, Data = instructor, Message = "you login successfully" });
        }
    }
}
