using Domain.Entities;

namespace Domain.Aggregates
{
    public class UserAggregate
    {
        public User User { get; private set; }
        public List<Message> Messages { get; private set; }
        public UserAggregate(User user)
        {
            User = user;
            Messages = new List<Message>();
        }
    }
}