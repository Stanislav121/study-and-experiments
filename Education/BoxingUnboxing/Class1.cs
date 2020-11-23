using System;
using System.Collections.Generic;
using System.Text;

namespace BoxingUnboxing
{
    class Class1
    {
        public void Run2()
        {
            {
                using (var ddd = new Disposable())
                {
                    // Используем объект d
                }

                // Выведет: Disposed: true? или Disposed: false?
                //Console.WriteLine("Disposed: {0}", d.Disposed);
            }

            {
                var yyy = new Disposable();
                using (yyy)
                {
                    // Используем объект d
                }

                // Выведет: Disposed: true? или Disposed: false?
                Console.WriteLine("Disposed: {0}", yyy.Disposed);
            }



        }
    }
}
