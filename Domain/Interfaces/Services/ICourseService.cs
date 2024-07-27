using Domain.DTO;
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
    }
}
