using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRemotingServer
{
    public class MyServer : MarshalByRefObject, IMyInterface
    {
        public string sayHello(string name)
        {
            return "你好：" + name;
        }
    }
}