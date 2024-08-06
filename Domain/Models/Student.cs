﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student :User
    {
        
        public List<Course>? Course { get; set; }
        public List<Exam>? Exams { get; set; }
    }
}
