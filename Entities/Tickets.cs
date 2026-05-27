namespace PulseDeskAPI.Entities;

using System.ComponentModel.DataAnnotations;

public class Ticket
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O ticket deve possuir um titulo")]
    public String Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O ticket deve possuir uma descrição")]
    public String Description { get; set; } = string.Empty;

    public string Status { get; set; } = "ABERTO";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }

    public User User { get; set; }
}