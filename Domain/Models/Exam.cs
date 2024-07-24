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

        public HashSet<Question> Questions { get; set; }
        public Instructor instructor { get; set; }
    }
}
