using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ITaskService
    {
        public  Task<ResultDTO> AddTask(TaskDTO taskDTO);
        public  Task<ResultDTO> GetTaskById(int id);
        public Task<ResultDTO> UpdateTask(int id, TaskDTO taskDTO);
        public Task<ResultDTO> GetTasks();
        public Task<ResultDTO> DeleteTask(int id);


    }
}
