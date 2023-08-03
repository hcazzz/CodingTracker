using CodingTracker;
var userInterface = new UserInterface();
var codingTrackerContext = new CodingTrackerContext();
var codingTrackerRepository = new CodingTrackerRepository(codingTrackerContext);
var controller = new Controller(userInterface, codingTrackerRepository);
string currentDirectory = Directory.GetCurrentDirectory();

var dbFilePath = Path.Combine(Directory.GetCurrentDirectory(), "coding-tracker.db");

// Check if the database file exists
bool databaseExists = File.Exists(dbFilePath);

// Create the context and ensure the database is created
using (var dbContext = new CodingTrackerContext()) {
    if (!databaseExists) {
        dbContext.EnsureDatabaseCreated();
    }
}

    controller.Run();

