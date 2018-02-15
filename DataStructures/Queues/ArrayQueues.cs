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

        public void Enqueue(T item)
        {
            if (_size == _items.Length)
            {
                var newSize = (_size == 0) ? 4 : _size * 2;
                var _newItems = new T[newSize];
                
                if(_size > 0)
                {
                    var _targetIndex = 0;

                    if (_tail < _head)
                    {
                        for (int i = _head; i < _items.Length; i++)
                        {
                            _newItems[_targetIndex++] = _items[i];
                        }

                        for (int i = 0; i <= _tail; i++)
                        {
                            _newItems[_targetIndex++] = _items[i];
                        }

                        _items = _newItems;
                    }
                    else
                    {
                        for (int i = _head; i <= _tail; i++)
                        {
                            _newItems[_targetIndex++] = _items[i];
                        }
                    }

                    _head = 0;
                    _tail = _targetIndex - 1; // Since we are using post incrememnt
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = _newItems;
            }

            if (_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            _items[_tail] = item;
            _size++;
        }

        public T Dqueue()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException("Queue is empty!");
            }

            T value = _items[_head];

            if (_head == _items.Length-1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }

            _size--;
            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new System.InvalidOperationException("Queue is empty!");
            }

            return _items[_head];
        }

        public int Count()
        {
           return _size;
        }

        public void Clear() {
            _size = 0;
            _head = 0;
            _tail = -1;        
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (int i = _head; i < _items.Length; i++)
                    {
                        yield return _items[i];
                    }

                    for (int i = 0; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
                else
                {
                    for (int i = _head; i <= _tail; i++)
                    {
                        yield return _items[i];
                    }
                }
            }
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
            AQueue<int> Q = new AQueue<int>();

            Q.Enqueue(3);
            Q.Enqueue(6);
            Q.Enqueue(9);

            foreach (var item in Q)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();

            Q.Dqueue();

            foreach (var item in Q)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();


            Console.WriteLine(Q.Peek());


            Console.WriteLine(Q.Count());

            Q.Clear();

            Console.WriteLine(Q.Count());

            Console.ReadLine();
        }
    }
}
