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
        public int grade { get; set; }
        public int ExamId { get; set; }
        public Level Level { get; set; }
        public List< Exam> Exam { get; set; }
        // you should add list choices when you create question
        public List<Choice> Choices { get; set; }
    }

    public enum Level
    {
        Simple,
        Medium,
        Hard
    }
}
