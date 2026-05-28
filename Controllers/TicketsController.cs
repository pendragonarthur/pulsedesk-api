using Microsoft.AspNetCore.Mvc;
using PulseDeskAPI.Data;
using PulseDeskAPI.DTOs.Ticket;
using PulseDeskAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace PulseDeskAPI.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ApplicationDbContext _context;


    public TicketController(ApplicationDbContext context)
    {
        _context = context;

    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var tickets = await _context.Tickets.Select(x => new TicketResponseDto
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description
        }).ToListAsync();
        return Ok(tickets);
    }

    [Authorize]
    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicket(CreateTicketDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int parsedUserId = int.Parse(userId!);

        var ticket = new Ticket
        {
            Title = dto.Title,
            Description = dto.Description,
            UserId = parsedUserId,
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return Ok(ticket);
    }

    [Authorize]
    [HttpGet("my-tickets")]
    public async Task<IActionResult> GetMyTickets()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int parsedUserId = int.Parse(userId!);

        var tickets = await _context.Tickets.Where(x => x.UserId == parsedUserId).ToListAsync();

        return Ok(tickets);
    }


    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int parsedUserId = int.Parse(userId!);

        var ticket = await _context.Tickets.Where(x => x.UserId == parsedUserId && x.Id == id).FirstOrDefaultAsync();

        if (ticket == null)
        {
            return NotFound("Ticket não encontrado");
        }
        return Ok(ticket);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicketById(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int parsedUserId = int.Parse(userId!);

        var ticket = await _context.Tickets.Where(x => x.UserId == parsedUserId && x.Id == id).FirstOrDefaultAsync();

        if (ticket == null)
        {
            return NotFound("Ticket não encontrado");
        }
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return Ok("Ticket deletado");
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicketById(int id, UpdateTicketDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int parsedUserId = int.Parse(userId!);

        var ticket = await _context.Tickets.Where(x => x.UserId == parsedUserId && x.Id == id).FirstOrDefaultAsync();

        if (ticket == null)
        {
            return NotFound("Ticket não encontrado");
        }
        ticket.Title = dto.Title;
        ticket.Description = dto.Description;
        await _context.SaveChangesAsync();

        return Ok(ticket);
    }

}