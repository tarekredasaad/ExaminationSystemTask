using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ExamDTO
    {
        public string title { get; set; }
        public int Score { get; set; }

        public int CourseId { get; set; }
        public TypeExam type { get; set; }
        public int NumberQuestions { get; set; }
    }
}
