using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Answer : BaseModel
    {
        public int ChoiceId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
        public int QuestionId { get; set; }
        
        public Question Question{ get; set; }
            

    }
}
