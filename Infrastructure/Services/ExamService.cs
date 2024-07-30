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
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        ICourseService courseService;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            this.courseService = courseService;
            this.courseService = courseService;
        }

        public async Task<ResultDTO> AddExam(AddExamDTO examDTO)
        {
            if (examDTO != null)
            {
                Exam exam = new Exam();
                string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
                //task = _mapper.Map<Tasks>(taskDTO);
                exam.title = examDTO.title;
                exam.InstructorId = member.id;
                exam.type = examDTO.type;
                exam.CourseId = examDTO.CourseId;
                exam.Score = examDTO.Score;
                exam.NumberQuestions = examDTO.NumberQuestions;
                var NewExam = _unitOfWork.ExamRepo.Create(exam);
                NewExam.Questions = examDTO.questions;
                _unitOfWork.commit();
                foreach(var _question in examDTO.questions)
                {

                    Question question = new Question();
                    question = _mapper.Map<Question>(_question);
                    question.ExamId = NewExam.id;
                    var newQuestion = _unitOfWork.QuestionRepo.Create(question);
                    _unitOfWork.commit();

                    foreach(var _choice in _question.Choices)
                    {
                        Choice choice = new Choice();
                        choice = _mapper.Map<Choice>(_choice);
                        choice.questionId = newQuestion.id;
                        var newChoice = _unitOfWork.ChoiceRepo.Create(choice);
                        _unitOfWork.commit();
                    }
                }

                return new ResultDTO() { StatusCode = 200, Data = NewExam, Message = "You added the Task successfully" };


            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
        }

        public async Task<ResultDTO> TakeExam(TakeExamDTO courseDTO)
        {
            if(courseDTO != null)
            {
                //CourseStudent CourseStudnet = await this.courseService.GetStudentCourse(courseDTO);
                string UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                Student student = _unitOfWork.StudentRepo.Get(s=>s.username == UserName);
                //Course course = _unitOfWork.CourseRepo.Get(c=>c.title == courseDTO.title);
                //if(course != null && student != null)
                //{
                //    bool IsStudentJoinCourse = _unitOfWork.CourseStudentRepo.GetAll().Any(sc => sc.CourseId == course.id && sc.StudentId == student.id);
                //    if(IsStudentJoinCourse)
                //    {
                        Exam exam = _unitOfWork.ExamRepo.Get(e=>e.title == courseDTO.ExamTitle);
                        if(exam != null)
                        {
                            
                            StudentExam studentExam =_unitOfWork.StudentExamRepo.Get(e=>e.StudentId == student.id && e.ExamId == exam.id);
                            if(studentExam != null)
                            {
                                if (studentExam.IsTaken)
                                {
                                    return new ResultDTO() { StatusCode = 400, Data = studentExam ,Message = "you can't take  exam agian" };
                                }
                                studentExam.IsTaken = true;


                                return new ResultDTO() { StatusCode = 400, Data = studentExam, Message = "you have taken quize successfully" };
                            }


                        }
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
                //}
                //}
            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }
    }
}
