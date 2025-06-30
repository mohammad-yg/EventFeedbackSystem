using EventFeedbackSystem.Application.Shared.Auth;
using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Events.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EventFeedbackSystem.Web.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;

    public EventsController(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet("/")]
    public async Task<IActionResult> GetUpcoming([FromQuery]GetUpcomingListInput input)
    {
        var result = await _eventsService.GetUpcomingList(input);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}
