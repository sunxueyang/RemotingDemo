using RemotingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemotingObjects;
using System.Text;
using System.Threading.Tasks;

namespace RemotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * winform客户端
            客户端执行之前必须保证 对应的服务端服务开启，以便对服务端接口进行注册。
            */


            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, false);
            IPerson obj = (IPerson)Activator.GetObject(typeof(RemotingObjects.IPerson), "tcp://localhost:9010/RemotingPersonService");
            RemotingServer.ITestProgram objPro = (RemotingServer.ITestProgram)Activator.GetObject(typeof(RemotingServer.ITestProgram), "tcp://localhost:9010/RemotingProgramService");


            if (obj == null)
            {
                Console.WriteLine("Couldn't crate Remoting Object 'Person'.");
            }

            Console.WriteLine("Please enter your name：");
            String name = Console.ReadLine();
            try
            {
                Console.WriteLine();
                Console.WriteLine("Put:");
                Console.WriteLine();
                Console.WriteLine(obj.getName(name));
                Console.WriteLine();
                Console.WriteLine(objPro.TestServiceName(name));
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
