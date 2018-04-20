using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorter = new SleepSorter();
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            list.Sort(new RandomComarer<int>());
            sorter.SortByThreads(list);
            Console.WriteLine("-----------------");
            sorter.SortByTasks(list);
            Console.ReadLine();
        }
    }
}
