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
        }
        public void IncrementX() { X++; }
        public int X { get; private set; }
        public int Y { get; set; }
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

    class Teplakov
    {
        public void Run1()
        {
            {
                A a = new A();
                Console.WriteLine("Исходное значение Mutable.X: {0}", a.Mutable.X);
                a.Mutable.IncrementX();
                Console.WriteLine("Mutable.X после вызова IncrementX(): {0}", a.Mutable.X);
            }

            {
                B b = new B();
                Console.WriteLine("Исходное значение M.X: {0}", b.M.X);
                b.M.IncrementX();
                b.M.IncrementX();
                b.M.IncrementX();
                Console.WriteLine("M.X после трех вызовов IncrementX: {0}", b.M.X);
            }

            {
                List<Mutable> lm = new List<Mutable> { new Mutable(x: 5, y: 5) };
                //lm[0].Y++; // Ошибка компиляции
                Console.WriteLine("Исходное значение M.X: {0}", lm[0].X);
                lm[0].IncrementX(); // ведет к изменению временной переменной
                Console.WriteLine("Mutable.X после вызова IncrementX(): {0}", lm[0].X);
            }

            {
                Mutable[] am = new Mutable[] { new Mutable(x: 5, y: 5) };
                Console.WriteLine("Исходные значения X: {0}, Y: {1}", am[0].X, am[0].Y);
                am[0].Y++;
                am[0].IncrementX();
                Console.WriteLine("Новые значения X: {0}, Y: {1}", am[0].X, am[0].Y);
            }

            {
                Mutable[] am = new Mutable[] { new Mutable(x: 5, y: 5) };
                IList<Mutable> lst = am;
                Console.WriteLine("Исходные значения X: {0}, Y: {1}", lst[0].X, lst[0].Y);
                //lst[0].Y++; // Ошибка компиляции
                lst[0].IncrementX(); // изменение временной переменной
                Console.WriteLine("Новые значения X: {0}, Y: {1}", lst[0].X, lst[0].Y);
            }

            {
                var x = new { Items = new List<int> { 1, 2, 3 }.GetEnumerator() };
                while (x.Items.MoveNext())
                {
                    Console.WriteLine(x.Items.Current);
                }
            }
        }

        public void Run2()
        {
            {
                using (var d = new Disposable())
                {
                    // Используем объект d
                }

                // Выведет: Disposed: true? или Disposed: false?
                //Console.WriteLine("Disposed: {0}", d.Disposed);
            }

            {
                var d = new Disposable();
                using (d)
                {
                    // Используем объект d
                }

                // Выведет: Disposed: true? или Disposed: false?
                Console.WriteLine("Disposed: {0}", d.Disposed);
            }

            {
                using (var d = new Disposable())
                {
                    // Переменую нельзя переприсвоить
                    //d = new Disposable();
                    // Нельзя инкрементировать ее свойство
                    //d.Counter++;
                    // Нельзя передавать по ref или out
                    //PassByRef(ref d);
                }
            }
            
        }
    }

    struct Disposable : IDisposable
    {
        public bool Disposed { get; private set; }
        public void Dispose() { Disposed = true; }
    }
}
