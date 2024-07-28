using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Exam : BaseModel
    {
        public string title { get; set; }
        public int Score { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public TypeExam type { get; set; }
        public int NumberQuestions { get; set; }
        [JsonIgnore]
        public List<Question>? Questions { get; set; }
        public Instructor? instructor { get; set; }
        [JsonIgnore]
        public List<Student>? Students { get; set; }
        public Course? course { get; set; }
    }
    public enum TypeExam
    {
        Quiz,
        Final
    }
}
