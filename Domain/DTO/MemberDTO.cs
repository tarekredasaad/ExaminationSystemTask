using DynamicAuthApi.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class MemberDTO
    {
        public string Name { get; set; }
        [ValidEmail(ErrorMessage = "The Email field must be a valid email address.")]
        public string Email { get; set; }
    }
}
