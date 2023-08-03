

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace CodingTracker;
internal class CodingTrackerContext : DbContext {
    public DbSet<CodingTracker> CodingTrackers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        
        var dbFilePath = Path.Combine(Directory.GetCurrentDirectory(), "coding-tracker.db");
        optionsBuilder.UseSqlite($"Data Source={dbFilePath}");

        
    
    }
    public void EnsureDatabaseCreated() {
        Database.EnsureCreated();
    }
}