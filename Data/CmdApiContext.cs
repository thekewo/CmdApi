using CmdApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Data
{
    public class CmdApiContext : DbContext
    {
        public CmdApiContext(DbContextOptions<CmdApiContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
