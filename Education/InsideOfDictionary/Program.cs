using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideOfDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new DictionaryAdd<MyClass, string>();
            dictionary.Add(new MyClass("aaa"), "aaa");
            dictionary.Add(new MyClass("ccc"), "ccc");
            dictionary.Add(new MyClass("bbb"), "bbb");

            var aaa = dictionary.GetValueOrDefault(new MyClass("aaa"));
            var bbb = dictionary.GetValueOrDefault(new MyClass("bbb"));
        }
    }
}
