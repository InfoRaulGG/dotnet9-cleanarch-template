using System;

namespace Domain.ValueObjects
{
    public class UserName
    {
        public string Value { get; }

        protected UserName() { }
        public UserName(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("User name cannot be empty.", nameof(value));

            Value = value;
        }

        public override string ToString() => Value;
        public override bool Equals(object obj)
        {
            if (obj is UserName other)
                return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

    }
}