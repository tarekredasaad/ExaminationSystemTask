using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class QuestionExamDTO
    {
        public string text { get; set; }
        public int grade { get; set; }
        //public int ExamId { get; set; }
        public Level Level { get; set; }
        public List<ChoiceDTO> Choices { get; set; }
    }
}
