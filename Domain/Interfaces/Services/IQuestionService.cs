using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IQuestionService
    {
         Task<ResultDTO> AddQuestion(QuestionDTO questionDTO);
          Task<ResultDTO> UpdateQuestion(UpdateQuestionDTO questionDTO);
        Task<ResultDTO> AddExistQuestionToExams(ExistQuestionDTO questionDTO);
        Task<ResultDTO> DeleteQuestion(int id);
    }
}
