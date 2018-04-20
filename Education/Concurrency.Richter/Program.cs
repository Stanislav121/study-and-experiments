using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency.Richter
{
    class Program
    {
        static void Main(string[] args)
        {
            var updater = new NonBlockingSynchronization();
            var person1 = new Person("Ivan", 18);
            var person2 = new Person("Jon", 55);

            var t1 = new Thread(TestUpdater);
            t1.Name = person1.Name;
            var t2 = new Thread(TestUpdater);
            t2.Name = person2.Name;

            var wrap1 = new Wrap
            {
                Updater = updater,
                Person = person1
            };
            var wrap2 = new Wrap
            {
                Updater = updater,
                Person = person2
            };
            t1.Start(wrap1);
            t2.Start(wrap2);
            t1.Join();
            t2.Join();
            
            Console.ReadLine();
        }

        private static void TestUpdater(object obj)
        {
            NonBlockingSynchronization updater = ((Wrap)obj).Updater;
            Person person = ((Wrap)obj).Person;

            for (int i = 0; i < 10; i++)
            {
                updater.Update(person);
                Console.WriteLine(updater.ToString());
            }
        }
    }

    class Wrap
    {
        public NonBlockingSynchronization Updater;
        public Person Person;
    }
}
