using Domain.TypedIds;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public UserName Name { get; private set; }
        public Email Email { get; private set; }

        public User()
        {
        }
        public User(UserName name, Email email)
        {
            Name = name;
            Email = email;
        }
        public User(UserId id, UserName name, Email email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}