using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithmsTests
{
    public class MockComparable: IComparable<MockComparable>, ICloneable
    {
        public int Value { get; private set; }
        public MockComparable(int a)
        {
            Value = a;
        }
        public int CompareTo(MockComparable other)
        {
            return this.Value >= other.Value ? 1 : -1;
        }

        public object Clone()
        {
            return new MockComparable(Value);
        }
    }

    public class MockPerson
    {
        public string Name;
        public string Adress;
        public int Age;
    }
}
