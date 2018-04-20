using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedListOneWay<string>();
            linkedList.AddNode(new LinkedListOneWayNode<string>("First"));
            linkedList.AddNode(new LinkedListOneWayNode<string>("Second"));
            linkedList.AddNode(new LinkedListOneWayNode<string>("Third"));
            linkedList.AddNode(new LinkedListOneWayNode<string>("Fourth"));

            PrintLinkedList(linkedList);
            Console.ReadLine();
        }

        private static void Reverse<T>(LinkedListOneWay<T> linkedList)
        {

        }

        private static void PrintLinkedList<T>(LinkedListOneWay<T> linkedList)
        {
            LinkedListOneWayNode<T> current;
            if (linkedList.Head != null)
            {
                current = linkedList.Head;
            }
            else
            {
                return;
            }
            while (true)
            {
                Console.WriteLine(current.Item);
                if (current.NextItemLink == null)
                    break;
                current = current.NextItemLink;
            }
        }
    }
}
