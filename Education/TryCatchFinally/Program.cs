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
                var a = new FinnalyWithOutOfMemory();
                a.Run();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            //IsNotCallInUsing();
            //TryCatchFinnalyException();
            //TestFinnally();            

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void IsNotCallInUsing()
        {
            using (var a = new DisposableCorrapted())
            {                
                Console.WriteLine("using");
            }
        }      

        private static void TryCatchFinnalyException()
        {
            int result;
            try
            {
                result = FaultedMethod();
            }
            catch (Exception ex)
            {
                result = Int32.Parse(ex.Message);
            }
            
            Console.WriteLine(result);
        }

        private static int FaultedMethod()
        {
            int a = 0;
            try
            {
                a = 1 + 2;
                //throw new Exception();
                return a;
            }
            catch (Exception e)
            {
                return 20;
            }
            finally
            {
                a = 7;
                ++a;
                //return a; Compile time error
                //throw new Exception(a.ToString());
            }
            return 10;
        }

        #region When finnaly not called

        private static void TestFinnally()
        {
            //TryCatchFinnalyException();
            
            try
            {
                FinnalyIsNotCall();
            }
            catch(Exception ex)
            {

            }
        }

        private static void FinnalyIsNotCallInUsing()
        {
            using (var a = new Disposable())
            {
                throw new Exception();
                Console.WriteLine("using");
            }
        }    

        private static void FinnalyIsNotCall()
        {
            File.Delete("output.txt");
            var file = new StreamWriter("output.txt");
            try
            {
                //System.Environment.Exit( 0 );
                //throw new Exception();
                //Recurcion(); // throw StackOverflowException
            }
            finally
            {
                file.WriteLine("finally");
                file.Flush();
            }            
        }

        private static void Recurcion()
        {
            var a = new Object();
            Recurcion();
        }

        #endregion

    }
}
