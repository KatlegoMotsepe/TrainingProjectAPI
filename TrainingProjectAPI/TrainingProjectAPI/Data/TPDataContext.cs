using TrainingProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace TrainingProjectAPI.Data
{
    public class TPDataContext : DbContext
    {
        public TPDataContext(DbContextOptions db) : base(db) { }
        
        public DbSet<User> Users { get; set; }
    }
}
