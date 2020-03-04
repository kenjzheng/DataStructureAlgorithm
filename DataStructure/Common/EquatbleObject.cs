using System;
using System.Diagnostics.CodeAnalysis;

namespace Common
{
    public class EquatbleObject : IEquatable<EquatbleObject>
    {
        public int ObjectValue { get; }

        public EquatbleObject(int value)
        {
            this.ObjectValue = value;
        }

        public bool Equals([AllowNull] EquatbleObject other)
        {
            return this.ObjectValue == other.ObjectValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            EquatbleObject myObj = obj as EquatbleObject;
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
