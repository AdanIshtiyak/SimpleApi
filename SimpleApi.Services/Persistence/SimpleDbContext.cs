using Microsoft.EntityFrameworkCore;
using SimpleApi.Services.Models;

namespace SimpleApi.Services.Persistence
{
  public class SimpleDbContext : DbContext
  {
    public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
  }
}
