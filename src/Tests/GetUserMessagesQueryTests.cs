using Xunit;
using Application.Queries;
using Domain.TypedIds;

namespace Tests
{
    public class GetUserMessagesQueryTests
    {
        [Fact]
        public void GetUserMessagesQuery_Sets_UserId()
        {
            var userId = new UserId(Guid.NewGuid());
            var query = new GetUserMessagesQuery(userId);

            Assert.Equal(userId, query.UserId);
        }
    }
}