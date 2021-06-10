﻿using CmdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Data
{
    public interface ICmdApiRepository
    {
        IEnumerable<Command> GetCommands();
        Command GetCommandById(int id);
    }
}