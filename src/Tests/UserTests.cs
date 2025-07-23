using Xunit;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.TypedIds;

namespace Tests
{
    public class UserTests
    {
        [Fact]
        public void User_Creation_Sets_Properties()
        {
            var id = new UserId(Guid.NewGuid());
            var name = new UserName("Alice");
            var email = new Email("alice@example.com");

            var user = new User(id, name, email);

            Assert.Equal(id, user.Id);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void User_Email_Must_Be_Valid()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Email("not-an-email"));
            Assert.Contains("invalid", ex.Message.ToLower());
        }

        [Fact]
        public void User_Name_Must_Not_Be_Empty()
        {
            var ex = Assert.Throws<ArgumentException>(() => new UserName(""));
            Assert.Contains("cannot be empty", ex.Message.ToLower());
        }          
    }
}