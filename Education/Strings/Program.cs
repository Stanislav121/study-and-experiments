using System;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello";
            string s2 = " world";
            string s3 = "Hello world";
            string s5 = "Hello world";
            string s4 = s1 + s2;

            Console.WriteLine(s3 == s4); // True
            Console.WriteLine(Object.ReferenceEquals(s3, s4));// False

            Console.WriteLine(s3 == s5); // True
            Console.WriteLine(Object.ReferenceEquals(s3, s5));// True
        }
    }
}
