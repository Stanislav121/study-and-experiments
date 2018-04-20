using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metanit
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstQuestion();
            Console.ReadLine();
        }

        private static void FirstQuestion()
        {
            //B obj1 = new A();
            //obj1.Foo();

            B objFoo2 = new B();
            objFoo2.Foo();
            A objFoo3 = new A();
            objFoo3.Foo();
            A objFoo4 = new B();
            objFoo4.Foo();

            B objBoo2 = new B();
            objBoo2.Boo();
            A objBoo3 = new A();
            objBoo3.Boo();
            A objBoo4 = new B();
            objBoo4.Boo();

            B objCoo2 = new B();
            objCoo2.Coo();
            A objCoo3 = new A();
            objCoo3.Coo();
            A objCoo4 = new B();
            objCoo4.Coo();

            B objDoo2 = new B();
            objDoo2.Doo();
            A objDoo3 = new A();
            objDoo3.Doo();
            A objDoo4 = new B();
            objDoo4.Doo();


        }

        class A
        {
            public virtual void Foo()
            {
                Console.WriteLine("Class A, Foo");
            }

            public void Boo()
            {
                Console.WriteLine("Class A, Boo");
            }

            public void Coo()
            {
                Console.WriteLine("Class A, Coo");
            }

            public virtual void Doo()
            {
                Console.WriteLine("Class A, Doo");
            }
        }
        class B : A
        {
            public override void Foo()
            {
                Console.WriteLine("Class B, Foo");
            }

            public new void Boo()
            {
                Console.WriteLine("Class B, Boo");
            }

            public void Coo()
            {
                Console.WriteLine("Class B, Coo");
            }

            public new void Doo()
            {
                Console.WriteLine("Class B, Doo");
            }
        }
    }
}
