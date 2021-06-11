using AutoMapper;
using CmdApi.Data;
using CmdApi.Dtos;
using CmdApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICmdApiRepository _repository;
        private readonly IMapper _mapper;

        public CommandsController(
            ICmdApiRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        //Get /api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //Get /api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
    }
}
