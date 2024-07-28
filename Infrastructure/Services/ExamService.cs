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

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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
    }
}
