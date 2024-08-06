using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICourseService
    {
        
        public Task<ResultDTO> AddCourse(CourseDTO courseDTO);
        Task<ResultDTO> UpdateCourse(UpdateCourseDTO courseDTO);
        Task<ResultDTO> enrollCourse(CourseDTO courseDTO);
        public Task<ResultDTO> GetCourses();
          Task<CourseStudent> GetStudentCourse(CourseDTO courseDTO);
        Task<ResultDTO> DeleteCourse(int id);
    }
}
