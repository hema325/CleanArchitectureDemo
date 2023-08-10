using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Entities
{
    public abstract class ValueObject: IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetAtomicValues();

        //equality and comparisons
        public bool Equals(ValueObject? other)
        {
            return other != null && ValuesAreEqualTo(other.GetAtomicValues());
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj is ValueObject other && ValuesAreEqualTo(other.GetAtomicValues());
        }

        private bool ValuesAreEqualTo(IEnumerable<object> other)
        {
            return GetAtomicValues().SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
        }


        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }
    }
}
