using System.ComponentModel.DataAnnotations;

namespace EventFeedbackSystem.Application.Shared.Auth.Dtos;

public class AddFeedbackInput
{
    public long EventId { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    [MaxLength(300)]
    [Required]
    public string Comment { get; set; }
}
