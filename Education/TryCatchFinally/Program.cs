using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
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
            Console.ReadLine();
        }

        private static int FaultedMethod()
        {
            int a = 0;
            try
            {
                a = 1 + 2;
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
                throw new Exception(a.ToString());
            }
            return 10;
        }
    }
}
