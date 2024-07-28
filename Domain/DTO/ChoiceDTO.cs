using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ChoiceDTO
    {
        public string text { get; set; }
       // public int questionId { get; set; }
        
        public bool IsRight { get; set; }
    }
}
