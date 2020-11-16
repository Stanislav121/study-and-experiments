using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitQuestions
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TestCompareStrings();
            //TestExceptions14();
            //Test6();
            //Question7();
            //Question4();

            Console.ReadLine();
        }

        private static void Question4()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((short)obj);
        }

        #region Question7

        private static void Question7()
        {
            var c = new C();
            A a = c;

            a.Print2();
            a.Print1();
            c.Print2();
        }

        public class A
        {
            public virtual void Print1()
            {
                Console.Write("A");
            }
            public void Print2()
            {
                Console.Write("A");
            }
        }
        public class B : A
        {
            public override void Print1()
            {
                Console.Write("B");
            }
        }
        public class C : B
        {
            new public void Print2()
            {
                Console.Write("C");
            }
        }

        #endregion

        #region Test6

        private static void Test6()
        {
            lock (syncObject)
            {
                Write();
            }
        }

        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }

        #endregion

        #region TestCompareStrings

        private static void TestCompareStrings()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Console.WriteLine(s1 == s2);
            Console.WriteLine(((object)s1) == ((object)s2));
            Console.WriteLine(s2 == s3);
            Console.WriteLine(((object)s2) == ((object)s3));
            Console.ReadLine();
        }

        #endregion

        #region TestExceptions14

        private static void TestExceptions14()
        {
            try
            {
                Calc();
            }
            catch (MyCustomException e)
            {
                Console.WriteLine("Catch MyCustomException");
                throw;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Catch Exception");
            }
            Console.ReadLine();
        }

        class MyCustomException : DivideByZeroException
        {

        }

        private static void Calc()
        {
            int result = 0;
            var x = 5;
            int y = 0;
            try
            {
                result = x / y;
            }
            catch (MyCustomException e)
            {
                Console.WriteLine("Catch DivideByZeroException");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Catch Exception");
            }
            finally
            {
                throw new MyCustomException();
            }
        }

        #endregion
    }
}
