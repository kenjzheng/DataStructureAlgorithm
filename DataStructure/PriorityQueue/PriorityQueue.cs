using System;
using System.Collections.Generic;
using System.Text;
using DynamicArray;

namespace PriorityQueue
{
    //using binary heap for implementation
    public class PriorityQueue<T> : IPQueue<T> where T:IComparable<T>, IEquatable<T>
    {
        IDynamicArray<T> array = null;
        private int tailIndex = -1;

        public PriorityQueue()
        {
            array = new DynamicArray<T>(10);
        }

        public void Add(T t)
        {
            var index = array.Add(t);
            tailIndex++;

            //check invariant
            BubbleUp(index);
        }

        public void Clear()
        {
            array.Clear();
        }

        public bool Contains(T t)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public T Poll()
        {
            (array[0], array[tailIndex]) = (array[tailIndex], array[0]);
            var returnValue = array[tailIndex];
            array.RemoveAt(tailIndex);
            tailIndex--;
            SwimDown(0);

            return returnValue;
        }

        public bool Remove(T t)
        {
            throw new NotImplementedException();
        }

        private int GetParentIndex(int childIndex)
        {
            return childIndex % 2 == 1 ? childIndex / 2 : childIndex / 2 - 1;
        }

        private void BubbleUp(int childIndex)
        {
            if (childIndex == 0)
            {
                return;
            }

            var parentIndex = GetParentIndex(childIndex);

            if (array[parentIndex].CompareTo(array[childIndex]) > 0)
            {
                (array[parentIndex], array[childIndex]) = (array[childIndex], array[parentIndex]);

                BubbleUp(parentIndex);
            }
            else
            {
                return;
            }
        }

        private void SwimDown(int parentIndex)
        {
            var leftChildIndex = parentIndex * 2 + 1;
            var rightChildIndex = parentIndex * 2 + 2;

            if (rightChildIndex <= tailIndex) //two children
            {
                if (array[leftChildIndex].CompareTo(array[rightChildIndex]) <= 0) //left is smaller than right, or tie
                {
                    if (array[parentIndex].CompareTo(array[leftChildIndex]) > 0) //larger than left
                    {
                        (array[parentIndex], array[leftChildIndex]) = (array[leftChildIndex], array[parentIndex]);
                        SwimDown(leftChildIndex);
                    }
                    else if (array[parentIndex].CompareTo(array[rightChildIndex]) > 0) //smaller than left but larger than right
                    {
                        (array[parentIndex], array[rightChildIndex]) = (array[rightChildIndex], array[parentIndex]);
                        SwimDown(rightChildIndex);
                    }
                }
                else
                {
                    if (array[parentIndex].CompareTo(array[rightChildIndex]) > 0)
                    {
                        (array[parentIndex], array[rightChildIndex]) = (array[rightChildIndex], array[parentIndex]);
                        SwimDown(rightChildIndex);
                    }
                }
            }
            else if (leftChildIndex <= tailIndex) //one left child
            {
                if (array[parentIndex].CompareTo(array[leftChildIndex]) > 0) //larger than left
                {
                    (array[parentIndex], array[leftChildIndex]) = (array[leftChildIndex], array[parentIndex]);
                }
            }

            return;
        }
    }
}
