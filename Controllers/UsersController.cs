namespace PulseDeskAPI.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PulseDeskAPI.Data;
using PulseDeskAPI.DTOs.User;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize]
    [HttpGet("list")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users.Select(x => new UserResponseDto
        {
            Id = x.Id,
            Email = x.Email,
            Name = x.Name
        }).ToListAsync();
        return Ok(users);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("ID de Usuário não encontrado");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Ok("Usuário deletado");
    }
}