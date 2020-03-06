using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
    public class DynamicArray<T> : IDynamicArray<T> where T : IEquatable<T>, IComparable<T>
    {
        private int initialArraySize = 10;
        private int pointer = 0;
        private T[] array;

        public DynamicArray()
        {
            array = new T[initialArraySize];
        }

        public DynamicArray(int arraySize) 
        {
            initialArraySize = arraySize;
            array = new T[initialArraySize];
        }

        public T this[int index] { get => Get(index); set => Set(index, value); }

        public int Size { get => array.Length; }

        public void Clear()
        {
            array = new T[initialArraySize];
            pointer = 0;
        }

        public bool Contains(T t)
        {
            foreach (T target in array)
            {
                if (t.Equals(target))
                {
                    return true;
                }
            }

            return false;
        }

        public T Get(int index)
        {
            return array[index];
        }

        public int IndexOf(T t)
        {
            for (int i = 0; i<array.Length; i++)
            {
                if (array[i].Equals(t))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Remove(T t)
        {
            for (int i=0; i<array.Length; i++)
            {
                if (array[i].Equals(t))
                {
                    Array.Clear(array, i, 1);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            Array.Clear(array, index, 1);
        }

        public void Set(int index, T t)
        {
            array[index] = t;
        }

        public int Add(T t)
        {
            if (pointer < array.Length)
            {
                array[pointer] = t;
            }
            else
            {
                var newArray = new T[array.Length * 2];
                for (int i=0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
                array[pointer] = t;
            }

            pointer++;
            return pointer-1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i= 0; i<array.Length; i++)
            {
                if (array[i] != null)
                {
                    yield return array[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
