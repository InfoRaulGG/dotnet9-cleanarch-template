using System;

namespace Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        protected Email() { }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Email is invalid.", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
        public override bool Equals(object obj)
        {
            if (obj is Email other)
                return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
            return false;
        }
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;
    }
}