﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ExamQuestion : BaseModel
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }

        public Question? Question { get; set; }
        public Exam? Exam { get; set; }
    }
}
