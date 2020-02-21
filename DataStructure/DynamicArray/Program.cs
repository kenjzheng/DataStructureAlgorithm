using System;
using System.Collections.Generic;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial size is 2
            IDynamicArray<int> array = new DynamicArray<int>(2);
            var result = new List<int>();

            //dynamicly increases to 10
            for(int i=0; i<=15; i++)
            {
                array.Add(i);
            }

            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            Console.WriteLine(string.Join(',', result));

            array.Set(5, 100);
            array.Remove(2);

            enumerator = array.GetEnumerator();
            result.Clear();

            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            Console.WriteLine(string.Join(',', result));

            array.Clear();
            result.Clear();
            enumerator = array.GetEnumerator();

            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }

            Console.WriteLine(string.Join(',', result));
        }
    }
}
