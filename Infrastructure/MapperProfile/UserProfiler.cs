using AutoMapper;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MapperProfile
{
    public class UserProfiler :Profile
    {

        public UserProfiler()
        {
            CreateMap<Instructor, InstructorDTO>().ReverseMap();
            CreateMap<Student, UserDTO>();
        }
    }
}
