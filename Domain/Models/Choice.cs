using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Choice : BaseModel
    {
        public string text {  get; set; }
        public int questionId { get; set; }
        public Question question { get; set; }
        public bool IsRight { get; set; }
    }
}
