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
    }
}
