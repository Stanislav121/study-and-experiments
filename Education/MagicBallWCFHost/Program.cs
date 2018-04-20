using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfFirstLib;

namespace MagicBallWCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start host");
            using (ServiceHost host = new ServiceHost(typeof(MagicBallFirst)))
            {
                host.Open();
                Console.WriteLine("Host is ready");
                Console.ReadLine();
            }
        }
    }
}
