using System.ComponentModel.DataAnnotations;

namespace PulseDeskAPI.DTOs.Ticket;

public class CreateTicketDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

}