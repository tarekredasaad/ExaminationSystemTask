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
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDTO> AddTask(TaskDTO taskDTO)
        {
            if (taskDTO != null)
            {
                Tasks task = new Tasks();
                TeamMember member = _unitOfWork.TeamMemberRepo.Get(x => x.id == taskDTO.memberId);

                task = _mapper.Map<Tasks>(taskDTO);
                task.teamMember = member;
                var NewTask = _unitOfWork.TasksRepo.Create(task);
                _unitOfWork.commit();

                return new ResultDTO() { StatusCode = 200, Data = NewTask, Message = "You added the Task successfully" };


            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
        }

        public async Task<ResultDTO> GetTaskById(int id)
        {
            if(id != null)
            {
                Tasks myTask = _unitOfWork.TasksRepo.GetById(id);
                return new ResultDTO() { StatusCode = 200, Data = myTask, Message = "Your operation Has done successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

        public async Task<ResultDTO> GetTasks()
        {
           List<Tasks> tasks = (List<Tasks>)_unitOfWork.TasksRepo.GetAll("teamMember");
            return new ResultDTO() { StatusCode = 200, Data = tasks, Message = "Your operation Has done successfully" };

        }
        public async Task<ResultDTO> UpdateTask(int id, TaskDTO taskDTO)
        {
            if(taskDTO != null && id != null) 
            {
                Tasks myTask = _unitOfWork.TasksRepo.GetById(id);
                myTask = _mapper.Map<Tasks>(taskDTO);
                myTask.id = id;
                var task = _unitOfWork.TasksRepo.Update(myTask);
                _unitOfWork.commit();

                return new ResultDTO() { StatusCode = 200, Data = myTask, Message = "You Updated the Task successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }

        }

        public async Task<ResultDTO> DeleteTask(int id)
        {
            if (id != null)
            {
               _unitOfWork.TasksRepo.Delete(id);
                _unitOfWork.commit();
                return new ResultDTO() { StatusCode = 200, Data = "Your Task Has deleted successfully", Message = "Your operation Has done successfully" };

            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
        }

    }
}
