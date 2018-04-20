using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SleepSort
{
    class SleepSorter
    {
        public IList<int> SortByThreads(IList<int> list)
        {
            var sortedList = new List<int>();

            var threads = new List<Thread>();
            foreach (var item in list)
            {
                var thread = new Thread(AddItem);
                threads.Add(thread);
                thread.Start(Tuple.Create(sortedList, item));
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            return sortedList;
        }

        public IList<int> SortByTasks(IList<int> list)
        {
            var sortedList = new List<int>();

            var tasks = new List<Task>();
            foreach (var item in list)
            {
                Task task = new Task(() => AddItem(Tuple.Create(sortedList, item)));
                tasks.Add(task);
                task.Start();
            }
            foreach (var task in tasks)
            {
                task.Wait();
            }
            return sortedList;
        }

        private void AddItem(object obj)
        {
            var tuple = (Tuple<List<int>, int>) obj;
            var sortedList = tuple.Item1;
            var item = tuple.Item2;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(item * 3000);
            sortedList.Add(item);
        }
    }
}
