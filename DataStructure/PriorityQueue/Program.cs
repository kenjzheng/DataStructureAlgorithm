using System;
using Common;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            IPQueue<EquatbleObject> pq = new PriorityQueue<EquatbleObject>();
            var random = new Random();
            for (int i=0; i<30; i++)
            {
                pq.Add(new EquatbleObject(random.Next(0, 15)));
            }

            while (!pq.IsEmpty())
            {
                var obj = pq.Poll();
                Console.WriteLine(obj.ObjectValue);
            }

            Console.ReadLine();

            pq.Clear();
            pq.Add(new EquatbleObject(21));
            pq.Add(new EquatbleObject(11));
            pq.Add(new EquatbleObject(5));
            pq.Add(new EquatbleObject(4));
            pq.Add(new EquatbleObject(28));
            pq.Add(new EquatbleObject(1));
            pq.Add(new EquatbleObject(3));
            pq.Add(new EquatbleObject(7));

            pq.Remove(new EquatbleObject(5));

            while (!pq.IsEmpty())
            {
                var obj = pq.Poll();
                Console.WriteLine(obj.ObjectValue);
            }

            Console.ReadLine();
        }
    }
}
