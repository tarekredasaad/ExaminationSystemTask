using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Course : BaseModel
    {
        public string title { get; set; }
        public Instructor instructor { get; set; }
        public HashSet<Student> students { get; set; }


    }
}
