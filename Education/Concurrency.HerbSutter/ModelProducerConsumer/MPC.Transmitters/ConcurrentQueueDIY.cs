using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MPC.Transmitters
{
    public class ConcurrentQueueDIY<T>
    {
        private Node<T> _tail;

        private Node<T> _head;

        public void Enqueue(T item)
        {
            if (_tail == null)
            {
                _head = _tail = new Node<T>(item);
                return;
            }

            var node = new Node<T>(item);
            var tempTail = _tail;
            while (Interlocked.CompareExchange(ref _tail.Next, node, null) != null)
            {
                _tail = tempTail.Next;
            }

            //var node = new Node<T>(item);
            //var tempTail = _tail;
            //while (Interlocked.CompareExchange(ref _tail, node, tempTail) != tempTail)
            //{
            //    tempTail.Next = _tail;
            //}

        }

        public bool TryDequeue(out T result)
        {
            if (_head == null)
            {
                result = default(T);
                return false;
            }

            var tempHead = _head;
            while (Interlocked.CompareExchange(ref _head, tempHead.Next, tempHead) != tempHead)
            {
                tempHead = _head;
            }
            result = tempHead.Value;


            //result = _head.Value;
            //_head = _head.Next;

            return true;
        }

        public long Count { get { return _head == null ? 0 : 1; } }


        public class Node<P>
        {
            public P Value { get; private set; }

            public Node<P> Next;
            public Node(P value)
            {
                Value = value;
            }
                
        }
    }
}
