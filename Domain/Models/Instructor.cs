using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Instructor :User
    {

        [JsonIgnore]
        public HashSet<Exam>? Exams { get; set; }

    }
}
