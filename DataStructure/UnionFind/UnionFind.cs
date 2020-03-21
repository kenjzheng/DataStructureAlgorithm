using System;
using System.Collections.Generic;
using System.Text;
using DynamicArray;

namespace UnionFind
{
    public class UnionFind<T> where T:IEquatable<T>, IComparable<T>
    {
        private readonly IDynamicArray<int> roots;
        private readonly IDynamicArray<int> groupSizes;
        private readonly IDynamicArray<T> objects;
        private readonly Dictionary<int, int> dictionary;
        private int groupCount = 0;
        
        public UnionFind(List<T> items)
        {
            roots = new DynamicArray<int>(items.Count);
            groupSizes = new DynamicArray<int>(items.Count);
            objects = new DynamicArray<T>(items.Count);

            dictionary = new Dictionary<int, int>();
            groupCount = items.Count;

            for (int i= 0; i<roots.Size; i++)
            {
                roots[i] = i;
                groupSizes[i] = 1;
                objects[i] = items[i];
                dictionary.Add(items[i].GetHashCode(), i);
            }
        }

        public void Union(T x, T y)
        {
            int rootX = FindRoot(x);
            int rootY = FindRoot(y);

            //if root are same, x and y are in same group
            if (rootX == rootY)
            {
                return;
            }

            //check the size of both groups, small group joins big group
            if (groupSizes[rootX] < groupSizes[rootY])
            {
                groupSizes[rootY] += groupSizes[rootX];
                roots[rootX] = rootY;
            }
            else
            {
                groupSizes[rootX] += groupSizes[rootY];
                roots[rootY] = rootX;
            }

            //once merged, groups reduces
            groupCount--;
        }

        public int FindRoot(T x)
        {
            var root = dictionary[x.GetHashCode()];
            
            while (roots[root] != root)
            {
                root = roots[root];
            }

            return root;
        }

        public bool Connected(T x, T y)
        {
            return FindRoot(x) == FindRoot(y);
        }
    }
}
