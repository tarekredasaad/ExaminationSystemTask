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
    public class QuestionProfile :Profile
    {
        public QuestionProfile() 
        {
            CreateMap<Question, QuestionExamDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Question, UpdateQuestionDTO>().ReverseMap();
        }

    }
}
