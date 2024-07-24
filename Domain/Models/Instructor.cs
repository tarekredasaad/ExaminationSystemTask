using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Instructor :User
    {
        
        public HashSet<Exam> Exams { get; set; }

    }
}
