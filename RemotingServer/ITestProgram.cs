﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
    public interface ITestProgram
    {
        string TestServiceName(string name);
    }
}
