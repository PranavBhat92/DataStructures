using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class LQueue<T> : IEnumerable<T>
    {

        private LinkedList<T> _items = new LinkedList<T>();

        public void EnQueue(T item)
        {
            _items.AddLast(item);
        }


        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var val = _items.First.Value;
             _items.RemoveFirst();
            return val;
        }


        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items.First.Value;
        }

        public int Count()
        {
            return _items.Count;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }


    class LinkedListQueue
    {
    }
}
