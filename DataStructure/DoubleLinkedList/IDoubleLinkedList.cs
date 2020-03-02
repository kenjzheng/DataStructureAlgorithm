using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public interface IDoubleLinkedList<T> : IEnumerable<T> where T : IEquatable<T>
    {
        void Clear();

        int Size { get; }

        bool IsEmpty { get; }

        void Add(T t);

        void AddFirst(T t);

        void AddLast(T t);

        bool Contains(T t);

        bool Remove(T t);

        bool RemoveFirst();

        bool RemoveLast();

        T PeekFirst();

        T PeekLast();
    }
}
