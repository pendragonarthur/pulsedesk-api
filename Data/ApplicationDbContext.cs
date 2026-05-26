using Microsoft.EntityFrameworkCore;
using PulseDeskAPI.Entities;

namespace PulseDeskAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}