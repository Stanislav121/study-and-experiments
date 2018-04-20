using System;
using System.Threading;

namespace Concurrency.HerbSutter.LockFree
{
    class LockFreeStarter
    {
        public static void Start(LockFreeConstructions lockFreeConstruction, ParameterizedThreadStart start)
        {
            Console.WriteLine(start.Method);
            var americanName = "Jhon Smith 32";
            var russianName = "Ivan Smirnof 41";
            var unconsistensyPersonsCount = 0;
            for (int i = 0; i < 32; i++)
            {
                StartConcurrencyThreadEqual(start);
                var personName = lockFreeConstruction.ToString();
                if (personName != americanName && personName != russianName)
                {
                    unconsistensyPersonsCount++;
                }
                Console.WriteLine(personName);
                lockFreeConstruction.CleanUp();
            }
            Console.WriteLine(unconsistensyPersonsCount);
        }

        public static void StartConcurrencyThreadEqual(ParameterizedThreadStart start)
        {
            var thread1 = new Thread(start);
            var americanMan = new PersonDTO
            {
                Name = "Jhon",
                Surname = "Smith",
                Age = 32
            };
            

            var thread2 = new Thread(start);
            var russianMan = new PersonDTO
            {
                Name = "Ivan",
                Surname = "Smirnof",
                Age = 41
            };
            thread2.Start(russianMan);
            thread1.Start(americanMan);

            thread1.Join();
            thread2.Join();
        }

        public static void StartConcurrencyThreadDifferent(ParameterizedThreadStart start)
        {
            var thread1 = new Thread(start);
            var americanMan = new PersonDTO
            {
                Name = "Jhon",
                Surname = "Smith",
                Age = 32
            };
            
            var russianMan = new PersonDTO
            {
                Name = "Ivan",
                Surname = "Smirnof",
                Age = 41
            };
            thread1.Start(americanMan);
            start(russianMan);
            

            thread1.Join();
        }
    }
}
