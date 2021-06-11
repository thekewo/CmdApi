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



        //GET /api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET /api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST /api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateOrUpdateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //PUT /api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandCreateOrUpdateDto commandUpdateDto)
        {
            var commandModel = _repository.GetCommandById(id);

            if(commandModel is null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModel);

            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
