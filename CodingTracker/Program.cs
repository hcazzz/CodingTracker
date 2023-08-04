using CodingTracker;

var codingTrackerContext = new CodingTrackerContext();
var userValidation = new UserValidation();
var userInterface = new UserInterface(userValidation);
var codingTrackerRepository = new CodingTrackerRepository(codingTrackerContext);
var controller = new Controller(userInterface, codingTrackerRepository, userValidation);



    DatabaseInitializer.InitializeDatabase();
    controller.Run();

