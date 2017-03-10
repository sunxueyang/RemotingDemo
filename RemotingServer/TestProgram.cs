using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
   public class TestProgram : MarshalByRefObject, ITestProgram
    {
        public string TestServiceName(string name)
        {
            return $"Service_____{name}";
        }
    }
}
