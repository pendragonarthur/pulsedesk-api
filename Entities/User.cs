namespace PulseDeskAPI.Entities;

using System.ComponentModel.DataAnnotations;


public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha")]
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "Colaborador";

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}