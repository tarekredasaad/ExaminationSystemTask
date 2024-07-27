using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Exam : BaseModel
    {
        public string title { get; set; }
        public int Score { get; set; }

        public int CourseId { get; set; }
        public Type type { get; set; }
        public int NumberQuestions { get; set; }
        public HashSet<Question> Questions { get; set; }
        public Instructor instructor { get; set; }
        public Course course { get; set; }
    }
    public enum Type
    {
        Quiz,
        Final
    }
}
