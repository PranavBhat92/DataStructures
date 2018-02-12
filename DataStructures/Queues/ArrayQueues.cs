using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class AQueue<T> : IEnumerable<T>
    {
        T[] _items = new T[0];
        int _size = 0;
        int _head = 0;
        int _tail = -1;        

        public void Enqueue(T items)
        {
            
        }

        public T Dqueue()
        {
            T value = 
        }

        public T Peek() {

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }


    class ArrayQueues
    {
        static void Main(string[] args)
        {
        }
    }
}
