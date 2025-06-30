using System.ComponentModel.DataAnnotations;

namespace EventFeedbackSystem.Application.Shared.Shared;

public class PaginationInput
{
    [Range(0, 100)]
    public int page { get; set; }
    [Range(5, 100)]
    public int pageCount { get; set; }
}
