using AutoMapper;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MapperProfile
{
    public class TaskProfile :Profile
    {
        public TaskProfile()
        {
            CreateMap<Tasks, TaskDTO>();
            CreateMap<TaskDTO, Tasks>();
        }
    }
}
