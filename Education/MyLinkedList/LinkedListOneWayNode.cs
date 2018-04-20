using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class LinkedListOneWayNode<T>
    {
        private readonly T _item;
        private LinkedListOneWayNode<T> _nextItemLink;

        public T Item 
        {
            get { return _item; }
        }

        public LinkedListOneWayNode<T> NextItemLink
        {
            get { return _nextItemLink; }
            set { _nextItemLink = value; }
        }

        public LinkedListOneWayNode(T item)
        {
            _item = item;
        }
    }
}
