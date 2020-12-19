using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
                TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

                //var a = new FinnalyWithOutOfMemory();
                //a.Run();

                //TryExceptions.IsNotCallInUsing();
                //TryExceptions.TryCatchFinnalyException();
                //TryExceptions.TestFinnally();     

                ExceptionsInConcurrency.Run();
                Console.WriteLine("Bbb");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in main {0}", e.GetType()); ;
            }                   

            Console.WriteLine("Press any key to exit");
            var counter = 0;
            while (true)
            {
                Thread.Sleep(100);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                counter++;
                //if (counter == 200)
                //    break;
            }
            Console.ReadLine();
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);            
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
           // Console.WriteLine(e.Exception);
        }
    }
}
