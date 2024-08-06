using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDTO> AddMember(MemberDTO memberDTO)
        {
            if (memberDTO != null)
            {
                TeamMember member = new TeamMember();
                //TeamMember member = _unitOfWork.TeamMemberRepo.Get(x => x.id == taskDTO.memberId);

                member = _mapper.Map<TeamMember>(memberDTO);
                //task.teamMember = member;
                TeamMember NewTask = await _unitOfWork.TeamMemberRepo.Create(member);
                _unitOfWork.commit();
                ResultDTO Result = new ResultDTO()
                {
                    StatusCode = 200,
                    Data = NewTask,
                    Message = "You added the Member successfully"
                };
                return  Result; 


            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
        }

        public async Task<ResultDTO> DeleteMember(int id)
        {
            if (id != null)
            {
                _unitOfWork.TeamMemberRepo.Delete(id);
                _unitOfWork.commit();
                return new ResultDTO() { StatusCode = 200, Data = "Your Member Has deleted successfully", Message = "Your operation Has done successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

        public async Task<ResultDTO> GetMemberById(int id)
        {
            if (id != null)
            {
                TeamMember myMember = _unitOfWork.TeamMemberRepo.GetById(id);
               

                return new ResultDTO() { StatusCode = 200, Data = myMember, Message = "Your operation Has done successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
            //throw new NotImplementedException();
        }

        public async Task<ResultDTO> GetMembers()
        {
            List<TeamMember> tasks = (List<TeamMember>)_unitOfWork.TeamMemberRepo.GetAll();
            return new ResultDTO() { StatusCode = 200, Data = tasks, Message = "Your operation Has done successfully" };

        }

        public async Task<ResultDTO> UpdateMember(int id, MemberDTO memberDTO)
        {
            if (memberDTO != null && id != null)
            {
                TeamMember myTask = _unitOfWork.TeamMemberRepo.GetById(id);
                myTask = _mapper.Map<TeamMember>(memberDTO);
                myTask.id = id;
                var task = _unitOfWork.TeamMemberRepo.Update(myTask);
                _unitOfWork.commit();

                return new ResultDTO() { StatusCode = 200, Data = myTask, Message = "You Updated the Task successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }
    }
}
