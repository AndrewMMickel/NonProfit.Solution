using Microsoft.EntityFrameworkCore;

namespace NonProfitTracker.Models
{
  public class NonProfitTrackerContext : DbContext
  {
    public DbSet<NonProfit> NonProfits { get; set; }
    public DbSet<BoardMember> BoardMembers { get; set; }

    public NonProfitTrackerContext(DbContextOptions options) : base(options) { }
  }
}