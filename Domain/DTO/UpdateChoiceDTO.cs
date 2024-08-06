using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UpdateChoiceDTO
    {
        public int id {  get; set; }
        public string text { get; set; }
        public int questionId { get; set; }

        public bool IsRight { get; set; }
    }
}
