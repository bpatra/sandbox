using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithmsTests
{
    public class Mock: IComparable<Mock>, ICloneable
    {
        public int Value { get; private set; }
        public Mock(int a)
        {
            Value = a;
        }
        public int CompareTo(Mock other)
        {
            return this.Value >= other.Value ? 1 : -1;
        }

        public object Clone()
        {
            return new Mock(Value);
        }
    }
}
