using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonProject
{
    class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        static Singleton()
        {

        }

        private Singleton()
        {
            Console.WriteLine("Create Singleton");
        }

        public static Singleton Instance {
            get { return _instance; }
        }
    }
}
