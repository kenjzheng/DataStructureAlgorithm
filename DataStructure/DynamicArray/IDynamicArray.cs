﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    public interface IDynamicArray<T> : IEnumerable<T> where T : IComparable
    {
        int Size { get; }

        T this[int index] { get; set; }

        void Clear();

        T Get(int index);

        void Set(int index, T t);

        void RemoveAt(int index);

        bool Remove(T t);

        int IndexOf(T t);

        bool Contains(T t);

        void Add(T t);
    }
}
