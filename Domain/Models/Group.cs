using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Group :BaseModel
    {
        public List<Permission>? Permissions { get; set; }
    }
}
