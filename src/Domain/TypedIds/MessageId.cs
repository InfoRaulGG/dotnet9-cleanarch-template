using System;

namespace Domain.TypedIds
{
    public readonly struct MessageId
    {
        public Guid Value { get; }
        public MessageId(Guid value) => Value = value;
    }
}