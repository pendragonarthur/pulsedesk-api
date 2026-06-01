using System.ComponentModel.DataAnnotations;
using PulseDeskAPI.Enums;

namespace PulseDeskAPI.DTOs.Ticket;

public class CreateTicketDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public TicketCategory Category { get; set; } = TicketCategory.Administrativo;

    public TicketPriority Priority { get; set; } = TicketPriority.Baixa;

}