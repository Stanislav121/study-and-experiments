using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingUnboxing
{
    struct Mutable
    {
        public Mutable(int x, int y)
            : this()
        {
            X = x;
            Y = y;
            Id = Counter;
            Counter++;
            Cobj = new C();
        }
        public void IncrementX() { X++; }
        public int X { get; private set; }
        public int Y { get; set; }

        public int Id;

        private static int Counter;

        public C Cobj;
    }
    class A
    {
        public A() { Mutable = new Mutable(x: 5, y: 5); }
        public Mutable Mutable { get; private set; }
    }

    class B
    {
        public readonly Mutable M = new Mutable(x: 5, y: 5);
    }

    class C
    {
        public C()
        {
            Console.WriteLine("C");
            x = 5;
        }

        public int x;
    }

    class Teplakov
    {
        public void Run1()
        {
            {
                Console.WriteLine("Property");
                A a = new A();
                Console.WriteLine("Исходное значение Mutable.X: {0}", a.Mutable.X);
                a.Mutable.IncrementX();
                a.Mutable.Cobj.x++;
                Console.WriteLine($"x in C {a.Mutable.Cobj.x}");
                Console.WriteLine($"Id {a.Mutable.Id}");
                Console.WriteLine($"Id {a.Mutable.Id}");
                Console.WriteLine("Mutable.X после вызова IncrementX(): {0} \n", a.Mutable.X);
            }

            {
                Console.WriteLine("readonly field");
                B b = new B();
                Console.WriteLine("Исходное значение M.X: {0}", b.M.X);
                b.M.IncrementX();
                b.M.IncrementX();
                b.M.IncrementX();
                Console.WriteLine($"Id {b.M.Id}");
                Console.WriteLine($"Id {b.M.Id}");
                Console.WriteLine("M.X после трех вызовов IncrementX: {0}\n", b.M.X);
            }

            {
                Console.WriteLine("List");
                List <Mutable> lm = new List<Mutable> { new Mutable(x: 5, y: 5) };
                //lm[0].Y++; // Ошибка компиляции
                Console.WriteLine("Исходное значение M.X: {0}", lm[0].X);
                lm[0].IncrementX(); // ведет к изменению временной переменной
                Console.WriteLine($"Id {lm[0].Id}");
                Console.WriteLine("Mutable.X после вызова IncrementX(): {0}\n", lm[0].X);
            }

            {
                Console.WriteLine("Array");
                Mutable[] am = new Mutable[] { new Mutable(x: 5, y: 5) };
                Console.WriteLine("Исходные значения X: {0}, Y: {1}", am[0].X, am[0].Y);
                am[0].Y++;
                am[0].IncrementX();
                Console.WriteLine($"Id {am[0].Id}");
                Console.WriteLine("Новые значения X: {0}, Y: {1}\n", am[0].X, am[0].Y);
            }

            {
                Console.WriteLine("Array in List");
                Mutable[] am = new Mutable[] { new Mutable(x: 5, y: 5) };
                IList<Mutable> lst = am;
                Console.WriteLine("Исходные значения X: {0}, Y: {1}", lst[0].X, lst[0].Y);
                //lst[0].Y++; // Ошибка компиляции
                lst[0].IncrementX(); // изменение временной переменной
                Console.WriteLine($"Id {lst[0].Id}");
                Console.WriteLine("Новые значения X: {0}, Y: {1} \n", lst[0].X, lst[0].Y);
            }

            {
                //var x = new { Items = new List<int> { 1, 2, 3 }.GetEnumerator() };
                //while (x.Items.MoveNext())
                //{
                //    Console.WriteLine(x.Items.Current);
                //}
            }
        }        
    }

    
}
