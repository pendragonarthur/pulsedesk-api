using System.ComponentModel.DataAnnotations;
using PulseDeskAPI.Enums;

namespace PulseDeskAPI.DTOs.Ticket;

public class UpdateTicketDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public TicketStatus Status { get; set; }
    public TicketCategory? Category { get; set; }

    public TicketPriority Priority { get; set; }

}