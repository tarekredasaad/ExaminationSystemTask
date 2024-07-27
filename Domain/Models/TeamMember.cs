using DynamicAuthApi.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeamMember:BaseModel
    {
       
        public string Name { get; set; }
        [ValidEmail(ErrorMessage = "The Email field must be a valid email address.")]

        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<Tasks> Tasks { get; set; }
    }
}
