using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryCatchFinally
{
    class DisposableCorrapted : IDisposable
    {
        public DisposableCorrapted()
        {
            throw new Exception();
        }

        public void Dispose()
        {
            File.Delete("Disposable.txt");
            var file = new StreamWriter("Disposable.txt");
            file.WriteLine("Dispose");
            file.Flush();
            //Console.WriteLine("Dispose");
        }
    }
}
