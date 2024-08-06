using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentExam :BaseModel
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsTaken { get; set; }
        public bool Completed { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public int Assesment { get; set; }
    }
}
