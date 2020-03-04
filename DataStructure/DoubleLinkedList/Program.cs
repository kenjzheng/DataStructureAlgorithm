using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Common;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            IDoubleLinkedList<EquatbleObject> linkedList = new DoubleLinkedList<EquatbleObject>();
            
            //test Add() method
            for (int i=0; i<10; i++)
            {
                var obj = new EquatbleObject(i);
                linkedList.Add(obj);
            }

            linkedList.Clear();

            //test AddFirst() method
            for (int i = 0; i < 10; i++)
            {
                var obj = new EquatbleObject(i);
                linkedList.AddFirst(obj);
            }

            linkedList.Clear();

            //test RemoveFirst() method
            for (int i = 0; i < 3; i++)
            {
                var obj = new EquatbleObject(i);
                linkedList.Add(obj);
            }
            linkedList.RemoveFirst();

            linkedList.Clear();

            //test RemoveLast() method
            for (int i = 0; i < 3; i++)
            {
                var obj = new EquatbleObject(i);
                linkedList.Add(obj);
            }
            linkedList.RemoveLast();

            linkedList.Clear();

            //test GetEnumerator() method
            for (int i = 0; i < 10; i++)
            {
                var obj = new EquatbleObject(i);
                linkedList.Add(obj);
            }

            var enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var obj = enumerator.Current as EquatbleObject;
                Console.WriteLine(obj.ObjectValue.ToString());
            }

            //test Contains() method
            linkedList.Clear();
            linkedList.Add(new EquatbleObject(1));
            linkedList.Add(new EquatbleObject(2));
            linkedList.Add(new EquatbleObject(3));

            Console.WriteLine(linkedList.Contains(new EquatbleObject(2)));
            Console.WriteLine(linkedList.Contains(new EquatbleObject(5)));

            //test Remove() method
            linkedList.Remove(new EquatbleObject(1));
            Console.WriteLine(linkedList.Contains(new EquatbleObject(1)));
            linkedList.AddFirst(new EquatbleObject(1));
            linkedList.Remove(new EquatbleObject(2));
            enumerator = linkedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var obj = enumerator.Current as EquatbleObject;
                Console.WriteLine(obj.ObjectValue.ToString());
            }
            
            linkedList.Remove(new EquatbleObject(3));
            linkedList.Remove(new EquatbleObject(1));

            Console.ReadLine();
        }
    }
}
