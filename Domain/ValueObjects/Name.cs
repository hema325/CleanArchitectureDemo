using Domain.Common.Entities;

namespace Domain.ValueObjects
{
    public sealed class Name : ValueObject
    {
        public const int MaxLength = 120;

        //immutability
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Name Create(string value)
        {
            //type safety and encapsulation
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Name can't be null or empty");

            if (value.Length > MaxLength)
                throw new ArgumentOutOfRangeException("Name must be less than 120");

            return new Name(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
