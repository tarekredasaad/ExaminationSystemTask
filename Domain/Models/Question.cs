using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Question : BaseModel
    {
        public string text {  get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public HashSet<Choice> Choices { get; set; }
    }
}
