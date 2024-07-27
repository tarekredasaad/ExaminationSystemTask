using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class InstructorDTO
    {
        public string username { get; set; }
        public string? password { get; set; }
        public int GroupId => 1;
    }
}
