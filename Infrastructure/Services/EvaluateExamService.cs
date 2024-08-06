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
    public class EvaluateExamService : IEvaluateExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public EvaluateExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDTO> EvaluateExam(EvaluateExamDTO evaluateExamDTO)
        {
            if (evaluateExamDTO != null)
            {
                List<Answer> answers = (List<Answer>)_unitOfWork.AnswerRepo.GetAll(a => a.ExamId == evaluateExamDTO.ExamId).ToList();
                StudentExam studentExam = _unitOfWork.StudentExamRepo.Get(s => s.ExamId == evaluateExamDTO.ExamId);
                List<Question> questionList = new List<Question>();

                var Question = await _unitOfWork.ExamRepo.GetByID(evaluateExamDTO.ExamId, "Questions");
                questionList = Question.Questions;
                if (studentExam != null && studentExam.Completed && studentExam.Assesment
                     == 0)
                {

                    foreach (Answer answer in answers)
                    {
                        Question question = _unitOfWork.QuestionRepo.Get(q => q.ExamId == answer.ExamId && q.id == answer.QuestionId);
                        Choice choice = _unitOfWork.ChoiceRepo.Get(c => c.id == answer.ChoiceId && c.questionId == question.id);
                        studentExam.Assesment += choice.IsRight ? question.grade : 0;
                    }
                    await _unitOfWork.StudentExamRepo.Update(studentExam);
                    var result = ResultDTO.Sucess(studentExam);
                    return result;
                }
                //List<Choice> choices = _unitOfWork.ChoiceRepo.GetAll()

            }
                return ResultDTO.Faliure();

        }
    }

}
