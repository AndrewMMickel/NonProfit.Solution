using Microsoft.EntityFrameworkCore;

namespace NonProfitTracker.Models
{
    public class NonProfitTrackerContext : DbContext
    {
        public virtual DbSet<NonProfit> NonProfits { get; set; }
        public virtual DbSet<BoardMember> BoardMembers { get; set; }

        public NonProfitTrackerContext(DbContextOptions options) : base(options) { }
    }
}