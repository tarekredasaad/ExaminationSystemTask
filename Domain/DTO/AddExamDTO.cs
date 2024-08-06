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
       public ExamDTO ExamDTO { get; set; }

        public List<QuestionExamDTO> questions { get; set; }

        //public List<ChoiceDTO> choices { get; set; }
    }

}
