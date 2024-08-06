using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ChoiceService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
         _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDTO> AddChoice(ChoiceDTO choiceDTO)
        {
            if (choiceDTO != null)
            {
                Choice choice = new Choice();
                choice = _mapper.Map<Choice>(choiceDTO);
                choice = await _unitOfWork.ChoiceRepo.Create(choice);

                var result = ResultDTO.Sucess(choice);
                return result;

            }
            else
            {
                var result = ResultDTO.Faliure("invalid operation");
                return result;
            }
        }

        public async Task<ResultDTO> UpdateChoice(UpdateChoiceDTO choiceDTO)
        {
            if (choiceDTO != null)
            {
                Choice choice = new Choice();
                choice = _mapper.Map<Choice>(choiceDTO);
                await _unitOfWork.ChoiceRepo.Update(choice);

                var result = ResultDTO.Sucess(choice);
                return result;

            }
            else
            {
                var result = ResultDTO.Faliure("invalid operation");
                return result;
            }
        }
    }
}
