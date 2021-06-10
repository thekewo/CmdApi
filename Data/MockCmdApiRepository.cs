using CmdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Data
{
    public class MockCmdApiRepository : ICmdApiRepository
    {
        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan" };
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            { 
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle and Pan" }
            };

            return commands;
        }
    }
}
