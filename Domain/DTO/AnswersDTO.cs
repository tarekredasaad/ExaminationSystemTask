using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AnswersDTO
    {
        public int ExamId { get; set; }
        public List<AnswerQuestion> answerQuestions { get; set; }
        
    }

    public class AnswerQuestion
    {
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
    }
}
