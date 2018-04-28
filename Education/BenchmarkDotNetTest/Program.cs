using System;

namespace BenchmarkDotNetTest
{
    

    public class Program
    {
        public static void Main(string[] args)
        {
            //var a = new Example();
            //a.RunBenchmarks();

            var a = new SymbolValidation();
            a.RunBenchmarks();

            Console.ReadLine();
        }
    }
}
