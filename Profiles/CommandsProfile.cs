using AutoMapper;
using CmdApi.Dtos;
using CmdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateOrUpdateDto, Command>();
            CreateMap<Command, CommandCreateOrUpdateDto>();
        }
    }
}
