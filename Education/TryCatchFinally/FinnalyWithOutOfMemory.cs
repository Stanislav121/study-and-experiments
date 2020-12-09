using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchFinally
{
    class FinnalyWithOutOfMemory
    {
        private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();
        public void Run()
        {
            using (var d = new Disposable())
            {
                long counter = 0;
                while (true)
                {
                    //throw new Exception();
                    _dictionary.Add(counter.ToString() + "aaaaaaaaaaaaaaaaaaaaabbbbbbhygfhtfhftjhthth5m8ho5hmtuhgfhtlfihtofhgfbbbbbbbbbbbbbbbbb" + counter.ToString(),
                        counter.ToString() + "aaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbgfhgfhbbfffffffffffff44444444" + counter.ToString());
                    counter++;
                }
            }
        }
    }
}
