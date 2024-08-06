using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UpdateQuestionDTO
    {
        public int id { get; set; }
        public string text { get; set; }
        public int grade { get; set; }
        public int ExamId { get; set; }
        public Level Level { get; set; }
    }
}
