using Xunit;
using Application.Commands;

namespace Tests
{
    public class CreateUserCommandTests
    {
        [Fact]
        public void CreateUserCommand_Sets_Properties()
        {
            var name = "Bob";
            var email = "bob@example.com";

            var cmd = new CreateUserCommand(name, email);

            Assert.Equal(name, cmd.Name);
            Assert.Equal(email, cmd.Email);
        }
    }
}