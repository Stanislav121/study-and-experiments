using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class LinkedListOneWay<T>
    {
        public LinkedListOneWayNode<T> Head { get; private set; }

        private LinkedListOneWayNode<T> _current;

        public void AddNode(LinkedListOneWayNode<T> item)
        {
            if (Head == null)
            {
                Head = _current = item;
                return;
            }

            _current.NextItemLink = item;
            _current = item;
        }
    }
}
