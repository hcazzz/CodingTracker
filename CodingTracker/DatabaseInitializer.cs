namespace CodingTracker;
public static class DatabaseInitializer {
    public static void InitializeDatabase() {
        // Get the database file path
        var dbFilePath = Path.Combine(Directory.GetCurrentDirectory(), "coding-tracker.db");

        // Check if the database file exists
        bool databaseExists = File.Exists(dbFilePath);

        // Create the context and ensure the database is created
        using (var dbContext = new CodingTrackerContext()) {
            if (!databaseExists) {
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
