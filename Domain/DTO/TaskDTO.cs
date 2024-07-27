using DynamicAuthApi.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class TaskDTO
    {
        [NotEmpty(ErrorMessage = "The Name field cannot be empty or whitespace.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }
        [NotEmpty(ErrorMessage = "The Description field cannot be empty or whitespace.")]
        [StringLength(500, ErrorMessage = "The Description field cannot exceed 500 characters.")]

        public string Description { get; set; }
        public string Status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public int memberId { get; set; }
    }
}
