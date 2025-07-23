using System;

namespace Domain.TypedIds
{
    public readonly struct UserId
    {
        public Guid Value { get; }
        public UserId(Guid value) => Value = value;
    }
}