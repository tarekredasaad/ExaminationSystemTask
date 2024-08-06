using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper
            , IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = contextAccessor;
        }

        public async Task<ResultDTO> AddCourse(CourseDTO courseDTO)
        {
            if (courseDTO != null)
            {
                Course course = new Course();
              string userName =  _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
                //task = _mapper.Map<Tasks>(taskDTO);
                course.title = courseDTO.title;
                course.InstructorId = member.id;
                var NewCourse = _unitOfWork.CourseRepo.Create(course);
                //_unitOfWork.commit();

                return new ResultDTO() { StatusCode = 200, Data = NewCourse, Message = "You added the Task successfully" };


            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
        }

        public async Task<CourseStudent> GetStudentCourse(CourseDTO courseDTO)
        {
            if(courseDTO != null)
            {
                Course course = _unitOfWork.CourseRepo.Get(c => c.title == courseDTO.title);
                string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Student student = _unitOfWork.StudentRepo.Get(x => x.username == userName);
                CourseStudent courseStudent = _unitOfWork.CourseStudentRepo.Get(cs=>cs.CourseId == course.id && cs.StudentId == student.id);
                if(courseStudent == null)
                {
                    return null;
                }
                return courseStudent;
            }
            else
            {
                return null;
            }
        }
        public async Task<ResultDTO> GetCourses()
        {
            string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
            Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
            List<Course> courses = _unitOfWork.CourseRepo.GetAll(c => c.InstructorId == member.id).ToList();

            return  ResultDTO.Sucess(courses);
        }

        public async Task<ResultDTO> enrollCourse(CourseDTO courseDTO)
        {
            string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
            Student student = _unitOfWork.StudentRepo.Get(x => x.username == userName);
            Course course = _unitOfWork.CourseRepo.Get(c=>c.title == courseDTO.title);
            CourseStudent courseStudent = new CourseStudent();
            courseStudent.StudentId = student.id;
            courseStudent.CourseId = course.id;

            courseStudent.Course = course;
            courseStudent.Student = student;
            var CStudent = _unitOfWork.CourseStudentRepo.Create(courseStudent);
            _unitOfWork.commit();
            //List<Tasks> tasks = (List<Tasks>)_unitOfWork.TasksRepo.GetAll("teamMember");
            return new ResultDTO() { StatusCode = 200, Data = CStudent, Message = "Your operation Has done successfully" };

        }
        public async Task<ResultDTO> UpdateCourse(UpdateCourseDTO courseDTO)
        {
            if (courseDTO != null )
            {
                
                Course course = _mapper.Map<Course>(courseDTO);
               
                var task = _unitOfWork.CourseRepo.Update(course);
                _unitOfWork.commit();

                return new ResultDTO() { StatusCode = 200, Data = course, Message = "You Updated the Task successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }

        }

        public async Task<ResultDTO> DeleteCourse(int id)
        {
            if (id != 0 && id != null)
            {

                Course course = _unitOfWork.CourseRepo.Get(c => c.id == id);
                _unitOfWork.CourseRepo.Delete(id);

                return ResultDTO.Sucess(course);
            }
            return ResultDTO.Faliure();

        }






    }

}

