using Xunit;
using Application.Commands;
using Application.Validators;

namespace Tests
{
    public class CreateUserCommandValidatorTests
    {
        [Theory]
        [InlineData("Alice", "alice@example.com", true)]
        [InlineData("", "alice@example.com", false)]
        [InlineData("Alice", "not-an-email", false)]
        public void Validate_CreateUserCommand(string name, string email, bool isValid)
        {
            var validator = new CreateUserCommandValidator();
            var result = validator.Validate(new CreateUserCommand(name, email));
            Assert.Equal(isValid, result.IsValid);
        }
    }
}