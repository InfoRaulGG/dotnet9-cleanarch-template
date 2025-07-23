using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetMessages(Guid userId)
        {
            var userTypedId = new Domain.TypedIds.UserId(userId);
            var messages = await _mediator.Send(new GetUserMessagesQuery(userTypedId));
            return Ok(messages);
        }
    }
}