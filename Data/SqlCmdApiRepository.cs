using CmdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Data
{
    public class SqlCmdApiRepository : ICmdApiRepository
    {
        private readonly CmdApiContext _context;

        public SqlCmdApiRepository(CmdApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }
    }
}
