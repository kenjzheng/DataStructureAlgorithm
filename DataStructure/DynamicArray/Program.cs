using System;
using System.Collections.Generic;
using Common;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial size is 2
            IDynamicArray<EquatbleObject> array = new DynamicArray<EquatbleObject>(2);
            var result = new List<int>();

            //dynamicly increases to 10
            for(int i=0; i<=15; i++)
            {
                array.Add(new EquatbleObject(i));
            }

            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ObjectValue);
            }

            //Console.WriteLine(string.Join(',', result));

            array.Set(5, new EquatbleObject(100));
            array.Remove(new EquatbleObject(2));

            enumerator = array.GetEnumerator();
            result.Clear();

            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ObjectValue);
            }

            Console.WriteLine(string.Join(',', result));

            //array.Clear();
            //result.Clear();
            //enumerator = array.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    result.Add(enumerator.Current.ObjectValue);
            //}

            //Console.WriteLine(string.Join(',', result));

            Console.ReadLine();
        }
    }
}
