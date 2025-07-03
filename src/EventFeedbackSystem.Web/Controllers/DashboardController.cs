using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Events.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFeedbackSystem.Web.Controllers;

[Authorize]
public class DashboardController : BaseController
{
    private readonly IEventsService _eventsService;

    public DashboardController(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet]
    [ActionName("")]
    public async Task<IActionResult> Index()
    {
        var currentUserId = GetCurrentUserId();
        var result = await _eventsService.GetUserRegisterationsList(currentUserId);

        if (result.IsSuccess) return Ok(new DashboardIndexViewModel()
        {
            RegisteredEvents = result.Data
        });

        return BadRequest(result);
    }
}
