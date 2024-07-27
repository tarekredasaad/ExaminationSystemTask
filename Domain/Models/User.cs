using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User :BaseModel
    {

        //public long id { get; set; }
        //public string? api_key { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        //public string first_name { get; set; }
        //public string last_name { get; set; }
        //public string? email { get; set; }
        //public byte? is_banned { get; set; }
        //public byte? is_verified { get; set; }
        //public string? confirm_code { get; set; }
        //public DateTime? confirmed_at { get; set; }
        //public DateTime? password_changed_at { get; set; }
        //public string? display_name { get; set; }
        //public string? user_url { get; set; }
        //public byte? is_ldap { get; set; }
        //public long? created_by { get; set; }
        //public long? updated_by { get; set; }
        //public string? remember_token { get; set; }
       
        //public DateTime? deleted_at { get; set; }
        //public string? otp { get; set; }
        //public DateTime? otp_created_at { get; set; }
        //public long? profile_picture_id { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        //public virtual List<assessment_answers> assessment_answers { get; set; }
        //public virtual List<assessment_enrols> assessment_enrols { get; set; }
    }
}
