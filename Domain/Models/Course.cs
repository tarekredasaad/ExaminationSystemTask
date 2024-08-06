using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Course : BaseModel
    {
        public string title { get; set; }
        public int InstructorId { get; set; }
        public Instructor? instructor { get; set; }
        [JsonIgnore]
        public List<Student>? students { get; set; }
        [JsonIgnore]
        public List<Exam>? Exams { get; set;}


    }
}
