using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IChoiceService
    {
        public Task<ResultDTO> AddChoice(ChoiceDTO choiceDTO);

        public Task<ResultDTO> UpdateChoice(UpdateChoiceDTO choiceDTO);
    }
}
