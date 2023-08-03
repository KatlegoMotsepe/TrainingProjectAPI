using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NewTrainingProjectAPI.Models;

namespace NewTrainingProjectAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SessionDetails> SessionDetails { get; set; }
        public DbSet<SessionStats> SessionStats { get; set; }
        public DbSet<Points> Points { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
