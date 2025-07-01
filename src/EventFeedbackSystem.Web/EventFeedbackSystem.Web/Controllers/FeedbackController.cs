using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using EventFeedbackSystem.Application.Shared.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFeedbackSystem.Web.Controllers;

public class FeedbackController : BaseController
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost]
    [ActionName("{eventId}")]
    [Authorize]
    public async Task<IActionResult> Submit([FromRoute] long eventId, [FromBody] AddFeedbackInput input)
    {
        var userId = GetCurrentUserId();
        var result = await _feedbackService.AddFeedbackAsync(userId, eventId, input);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}
