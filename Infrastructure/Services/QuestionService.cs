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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDTO> AddQuestion(QuestionDTO questionDTO)
        {
            if (questionDTO != null)
            {
                Question question = new Question();
                question = _mapper.Map<Question>(questionDTO);
                question = await _unitOfWork.QuestionRepo.Create(question);

                

                ExamQuestion examQuestion = new ExamQuestion();
                examQuestion.Question = question;
                examQuestion.ExamId = questionDTO.ExamId;
                examQuestion =await _unitOfWork.ExamQuestionRepo.Create(examQuestion);

                var result = ResultDTO.Sucess(question);
                return result;

            }
            else
            {
                var result = ResultDTO.Faliure("invalid operation");
                return result;
            }
        }

        public async Task<ResultDTO> AddExistQuestionToExams(ExistQuestionDTO questionDTO)
        {
            if (questionDTO != null)
            {
                Question question = new Question();
                question = _unitOfWork.QuestionRepo.Get(q => q.id == questionDTO.questionId);
               
                if(question == null)
                {
                    return ResultDTO.Faliure();
                }


                Exam exam = _unitOfWork.ExamRepo.Get(e=>e.id == questionDTO.examId);

                if (exam == null)
                {
                    return ResultDTO.Faliure();
                }
                ExamQuestion examQuestion = new ExamQuestion();
                examQuestion.Question = question;
                examQuestion.ExamId = questionDTO.examId;
                examQuestion = await _unitOfWork.ExamQuestionRepo.Create(examQuestion);

                exam.NumberQuestions++;
                exam.Score += question.grade;
                 await _unitOfWork.ExamRepo.Update(exam);


                var result = ResultDTO.Sucess(question);
                return result;

            }
            else
            {
                var result = ResultDTO.Faliure("invalid operation");
                return result;
            }
        }

        public async Task<ResultDTO> UpdateQuestion(UpdateQuestionDTO questionDTO)
        {
            if (questionDTO != null)
            {
                Question question = new Question();
                question = _mapper.Map<Question>(questionDTO);
                 await _unitOfWork.QuestionRepo.Update(question);

                var result = ResultDTO.Sucess(question);
                return result;

            }
            else
            {
                var result = ResultDTO.Faliure("invalid operation");
                return result;
            }
        }

        public async Task<ResultDTO> DeleteQuestion(int id)
        {
            if (id != 0 && id != null)
            {

                Question question = _unitOfWork.QuestionRepo.Get(c => c.id == id);
                _unitOfWork.QuestionRepo.Delete(id);

                return ResultDTO.Sucess(question);
            }
            return ResultDTO.Faliure();

        }
    }
}
