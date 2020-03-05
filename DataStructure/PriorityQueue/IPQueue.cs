using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public interface IPQueue<T> where T:IComparable<T>, IEquatable<T>
    {
        public void Add(T t);

        public bool Remove(T t);

        public T Poll();

        public bool Contains(T t);

        public T Peek();

        public void Clear();
    }
}
