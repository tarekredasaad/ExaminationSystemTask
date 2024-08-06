using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IExamService
    {
        Task<ResultDTO> AddExam(AddExamDTO examDTO);
        public  Task<ResultDTO> TakeExam(TakeExamDTO courseDTO);
        public  Task<ResultDTO> GetExams();
        public Task<ResultDTO> ViewResult(ExamResultDTO examResultDTO);
        public  Task<ResultDTO> AddExamBySystem();
    }
}
