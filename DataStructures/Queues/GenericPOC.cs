using System;
using System.Collections;
using System.Collections.Generic;

namespace Queues
{
    public class GClass<T>
    {
        private T data { get; set; }

        public GClass(T data)
        {
            this.data = data;
        }

        public void displayDataType()
        {
            Console.WriteLine(data.GetType());
        }
    }

    public class GenericEnumerable<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public int Count()
        {
            return _items.Count;
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

    //public class GenericPOC
    //{
    //    public static void Main(string[] args)
    //    {
    //        GClass<int> intData = new GClass<int>(5);
    //        intData.displayDataType();

    //        GClass<string> stringData = new GClass<string>("Pranav");
    //        stringData.displayDataType();


    //        GenericEnumerable<int> intList = new GenericEnumerable<int>();
    //        intList.Add(5);
    //        intList.Add(10);
    //        intList.Add(15);
    //        intList.Add(20);
    //        intList.Add(25);

    //        foreach (var item in intList)
    //        {
    //            Console.WriteLine(item);
    //        }

    //        GenericEnumerable<string> stringList = new GenericEnumerable<string>();
    //        stringList.Add("P");
    //        stringList.Add("R");
    //        stringList.Add("A");
    //        stringList.Add("N");
    //        stringList.Add("A");
    //        stringList.Add("V");

    //        foreach (var item in stringList)
    //        {
    //            Console.WriteLine(item);
    //        }

    //        Console.ReadLine();
    //    }
    //}
}
