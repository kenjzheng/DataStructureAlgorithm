using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DoubleLinkedList
{
    public class MyObject : IEquatable<MyObject>
    {
        private int value;

        public int ObjectValue => value;

        public MyObject(int value)
        {
            this.value = value;
        }

        public bool Equals([AllowNull] MyObject other)
        {
            return this.ObjectValue == other.ObjectValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            MyObject myObj = obj as MyObject;
            if (myObj is null)
            {
                return false;
            }
            else
            {
                return this.Equals(myObj);
            }
        }
    }
}
