using System;
using System.Collections.Generic;
using System.Text;
using DynamicArray;

namespace PriorityQueue
{
    //using binary heap for implementation
    public class PriorityQueue<T> : IPQueue<T> where T:IComparable<T>, IEquatable<T>
    {
        IDynamicArray<T> array = new DynamicArray<T>(10);
        private int tailIndex = -1;

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
            tailIndex = -1;
        }

        public bool Contains(T t)
        {
            if (!IsEmpty())
            {
                var index = 0;
                while (index <= tailIndex)
                {
                    if (array[index].Equals(t))
                    {
                        return true;
                    }
                    index++;
                }
            }
            
            return false;
        }

        public T Peek()
        {
            if (!IsEmpty())
            {
                return array[tailIndex];
            }
            return default(T);
        }

        public T Poll()
        {
            if (!IsEmpty())
            {
                (array[0], array[tailIndex]) = (array[tailIndex], array[0]);
                var returnValue = array[tailIndex];
                array.RemoveAt(tailIndex);
                tailIndex--;
                SwimDown(0);

                return returnValue;
            }
            return default(T);
        }

        public bool Remove(T t)
        {
            if (!IsEmpty())
            {
                var index = 0;
                while (index <= tailIndex)
                {
                    if (array[index].Equals(t))
                    {
                        if (index != tailIndex)
                        {
                            (array[index], array[tailIndex]) = (array[tailIndex], array[index]);
                            array.RemoveAt(tailIndex);
                            tailIndex--;

                            if (array[index].CompareTo(array[GetParentIndex(index)]) < 0)
                            {
                                BubbleUp(index);
                            }
                            else
                            {
                                SwimDown(index);
                            }
                        }
                        else
                        {
                            array.RemoveAt(tailIndex);
                            tailIndex--;
                        }
                    }
                    index++;
                }
            }

            return false;
        }

        public bool IsEmpty() => tailIndex < 0;

        private int GetParentIndex(int childIndex)
        {
            return childIndex % 2 == 1 ? childIndex / 2 : childIndex / 2 - 1;
        }

        private int GetLeftChildIndex(int parentIndex) => parentIndex * 2 + 1;

        private int GetRightChildIndex(int parentIndex) => parentIndex * 2 + 2;

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
            var leftChildIndex = GetLeftChildIndex(parentIndex);
            var rightChildIndex = GetRightChildIndex(parentIndex);

            if (rightChildIndex <= tailIndex) //two children
            {
                if (array[leftChildIndex].CompareTo(array[rightChildIndex]) <= 0) //left is smaller than, equal to right
                {
                    if (array[parentIndex].CompareTo(array[leftChildIndex]) > 0) //larger than left
                    {
                        (array[parentIndex], array[leftChildIndex]) = (array[leftChildIndex], array[parentIndex]);
                        SwimDown(leftChildIndex);
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
            else if (leftChildIndex <= tailIndex) //one left child. when there is only left chid, this left chid is last one.
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
