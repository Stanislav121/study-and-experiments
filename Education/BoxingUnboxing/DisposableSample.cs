using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingUnboxing
{
    class DisposableSample
    {
        struct Disposable : IDisposable
        {
            public bool Disposed { get; private set; }
            public void Dispose() { Disposed = true; }
        }
        public void Run2()
        {
            {
                using (var fff = new Disposable())
                {
                    // Используем объект d
                    Console.WriteLine("inside {0}", fff.Disposed);
                }

                // Выведет: Disposed: true? или Disposed: false?
                //Console.WriteLine("Disposed: {0}", d.Disposed);
            }

            {
                Disposable ddd;
                using (ddd = new Disposable())
                {
                    // Используем объект d
                    Console.WriteLine("inside {0}", ddd.Disposed);
                }

                // Выведет: Disposed: true? или Disposed: false?
                Console.WriteLine("Disposed: {0}", ddd.Disposed);
            }

            {
                var yyy = new Disposable();
                using (yyy)
                {
                    Console.WriteLine("inside {0}", yyy.Disposed);
                    // Используем объект d
                    // Переменую нельзя переприсвоить
                    //d = new Disposable();
                    // Нельзя инкрементировать ее свойство
                    //d.Counter++;
                    // Нельзя передавать по ref или out
                    //PassByRef(ref d);
                }

                // Выведет: Disposed: true? или Disposed: false?
                Console.WriteLine("Disposed: {0}", yyy.Disposed);
            }



        }
    }
}
