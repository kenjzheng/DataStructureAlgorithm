using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            IDoubleLinkedList<MyObject> linkedList = new DoubleLinkedList<MyObject>();
            
            //test Add() method
            for (int i=0; i<10; i++)
            {
                var obj = new MyObject(i);
                linkedList.Add(obj);
            }

            linkedList.Clear();

            //test AddFirst() method
            for (int i = 0; i < 10; i++)
            {
                var obj = new MyObject(i);
                linkedList.AddFirst(obj);
            }

            linkedList.Clear();

            //test RemoveFirst() method
            for (int i = 0; i < 3; i++)
            {
                var obj = new MyObject(i);
                linkedList.Add(obj);
            }
            linkedList.RemoveFirst();

            linkedList.Clear();

            //test RemoveLast() method
            for (int i = 0; i < 3; i++)
            {
                var obj = new MyObject(i);
                linkedList.Add(obj);
            }
            linkedList.RemoveLast();

            linkedList.Clear();

            //test GetEnumerator() method
            for (int i = 0; i < 10; i++)
            {
                var obj = new MyObject(i);
                linkedList.Add(obj);
            }

            var enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var obj = enumerator.Current as MyObject;
                Console.WriteLine(obj.ObjectValue.ToString());
            }

            //test Contains() method
            linkedList.Clear();
            linkedList.Add(new MyObject(1));
            linkedList.Add(new MyObject(2));
            linkedList.Add(new MyObject(3));

            Console.WriteLine(linkedList.Contains(new MyObject(2)));
            Console.WriteLine(linkedList.Contains(new MyObject(5)));

            //test Remove() method
            linkedList.Remove(new MyObject(1));
            Console.WriteLine(linkedList.Contains(new MyObject(1)));
            linkedList.AddFirst(new MyObject(1));
            linkedList.Remove(new MyObject(2));
            enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var obj = enumerator.Current as MyObject;
                Console.WriteLine(obj.ObjectValue.ToString());
            }
            
            linkedList.Remove(new MyObject(3));
            linkedList.Remove(new MyObject(1));

            Console.ReadLine();
        }
    }
}
