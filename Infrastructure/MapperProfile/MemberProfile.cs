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
    public class MemberProfile :Profile
    {
        public MemberProfile()
        {
            CreateMap<TeamMember, MemberDTO>();
            CreateMap<MemberDTO, TeamMember>();
        }
    }
}
