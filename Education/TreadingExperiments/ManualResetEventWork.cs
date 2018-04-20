using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TreadingExperiments
{
    public class ManualResetEventWork
    {
        private readonly ManualResetEvent connection;

        public ManualResetEventWork()
        {
            connection = new ManualResetEvent(false);

            Thread startConnection = new Thread(StartConnection);
            startConnection.Start();

            if (!connection.WaitOne(new TimeSpan(0, 0, 0, 10)))
            {
                Console.WriteLine("Connection offline");
            }

            Console.WriteLine("Connection online");
        }

        private void StartConnection()
        {
            connection.Reset();
        }
    }
}
