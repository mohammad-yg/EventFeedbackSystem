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

    [HttpGet]
    [ActionName("")]
    public async Task<IActionResult> GetUpcoming([FromQuery] GetUpcomingListInput input)
    {
        var result = await _eventsService.GetUpcomingList(input);

        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    [ActionName("{id}")]
    public async Task<IActionResult> Get([FromRoute] long id)
    {
        var result = await _eventsService.GetEvent(id);

        if (result.IsSuccess)
            return Ok(result);


        if (result.ErrorKey == "NotFound")
            return NotFound(result);

        return BadRequest(result);
    }
}
