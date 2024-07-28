using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AddExamDTO
    {
        public string title { get; set; }
        public int Score { get; set; }
        
        public int CourseId { get; set; }
        public TypeExam type { get; set; }
        public int NumberQuestions { get; set; }

        public List<QuestionExamDTO> questions { get; set; }

        //public List<ChoiceDTO> choices { get; set; }
    }

}
