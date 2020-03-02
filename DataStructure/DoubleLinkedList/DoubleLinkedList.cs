using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T> where T : IEquatable<T>
    {
        private int count = 0;
        private Node<T> firstNode = null;
        private Node<T> lastNode = null;

        private class Node<K> where K: IEquatable<K>
        {
            public Node<K> child = null;
            public Node<K> parent = null;
            public K Self;

            public Node(K k)
            {
                this.Self = k;
            }

            public override bool Equals(object obj)
            {
                return Self.Equals(obj);
            }
        }

        public int Size => count;

        public bool IsEmpty => count == 0;

        public void Add(T t)
        {
            AddLast(t);
        }

        public void AddFirst(T t)
        {
            var node = new Node<T>(t);
            if (firstNode == null)
            {
                firstNode = node;
                lastNode = node;
            }
            else
            {
                node.child = firstNode;
                firstNode.parent = node;
                firstNode = node;
            }

            count++;
        }

        public void AddLast(T t)
        {
            var node = new Node<T>(t);
            if (lastNode == null)
            {
                firstNode = node;
                lastNode = node;
            }
            else
            {
                lastNode.child = node;
                node.parent = lastNode;
                lastNode = node;
            }

            count++;
        }

        public void Clear()
        {
            //If a group of objects contain references to each other, but none of these object are referenced directly or indirectly 
            //from stack or shared variables, then garbage collection will automatically reclaim the memory.
            this.firstNode = null;
            this.lastNode = null;
            this.count = 0;
        }

        public bool Contains(T t)
        {
            if (firstNode != null)
            {
                var currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Equals(t))
                    {
                        return true;
                    }
                    currentNode = currentNode.child;
                }
            }
            return false;
        }

        public T PeekFirst()
        {
            return firstNode.Self;
        }

        public T PeekLast()
        {
            return lastNode.Self;
        }

        public bool Remove(T t)
        {
            if (firstNode != null)
            {
                var currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Equals(t))
                    {
                        var child = currentNode.child;
                        var parent = currentNode.parent;

                        if (child != null && parent != null) //middle
                        {
                            parent.child = child;
                            child.parent = parent;
                        }
                        else if(child !=null && parent == null) //first
                        {
                            child.parent = null;
                            firstNode = child;
                        }
                        else if(child == null && parent != null) //last
                        {
                            parent.child = null;
                            lastNode = parent;
                        }
                        else
                        {
                            firstNode = null; //only one
                            lastNode = null;
                        }
                        count--;
                        return true;
                    }
                    currentNode = currentNode.child;
                }
            }
            return false;
        }

        public bool RemoveFirst()
        {
            if (firstNode != null)
            {
                var childNode = firstNode.child;
                childNode.parent = null;
                firstNode = childNode;
                count--;
                return true;
            }

            return false;
        }

        public bool RemoveLast()
        {
            if (lastNode != null)
            {
                var parentNode = lastNode.parent;
                parentNode.child = null;
                lastNode = parentNode;
                count--;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (firstNode != null)
            {
                yield return firstNode.Self;

                var childNode = firstNode.child;

                while (childNode != null)
                {
                    yield return childNode.Self;
                    childNode = childNode.child;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
