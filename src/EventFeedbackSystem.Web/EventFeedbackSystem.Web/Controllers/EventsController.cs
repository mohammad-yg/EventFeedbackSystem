using Asp.Versioning;
using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Events.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventFeedbackSystem.Web.Controllers;

public class EventsController : BaseController
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

    [HttpGet]
    [ActionName("{eventId}/register")]
    [Authorize]
    public async Task<IActionResult> Register([FromRoute] long eventId)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var userId = Int64.Parse(userIdString);

        var result = await _eventsService.Register(userId, eventId);
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}
