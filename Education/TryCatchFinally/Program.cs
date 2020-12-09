using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var a = new FinnalyWithOutOfMemory();
                //a.Run();

                //TryExceptions.IsNotCallInUsing();
                //TryExceptions.TryCatchFinnalyException();
                //TryExceptions.TestFinnally();     

                ExceptionsInConcurrency.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error {0}", e.GetType()); ;
            }



                   

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

    }
}
