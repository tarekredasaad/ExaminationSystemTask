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
    public class CourseProfile :Profile
    {
        public CourseProfile() 
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<Course, UpdateCourseDTO>();
        }

    }
}
