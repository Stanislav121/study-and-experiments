using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndFunctions.Core
{
    public class Functions
    {
        public void TestFunction()
        {
            var a = 1;
            var b = 2;
            AddToDictionary("First", () => { return Function1(a, b); });
        }

        private string Function1(int a, int b)
        {
            return "test";
        }

        private void AddToDictionary(string key, Func<string> add)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(key, add());
            var item = dictionary[key];
        }

       
    }
}
