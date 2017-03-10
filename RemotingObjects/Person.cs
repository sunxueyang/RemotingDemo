using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingObjects
{
    public interface IPerson
    {
        String getName(String name);

    }

    public class Person : MarshalByRefObject, IPerson
    {
        public Person()
        {
            Console.WriteLine("[Person]:Remoting Object 'Person' is activated.");
        }

        public String getName(String name)
        {
            return name;
        }
    }
}
