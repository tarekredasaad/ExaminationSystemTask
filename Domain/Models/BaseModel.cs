using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseModel
    {
        
        public int id { get; set; }
        //public DateTime? created_at { get; set; } = DateTime.Now;
        //public DateTime? updated_at { get; set; }
        public bool deleted { get; set; }
    }
}
