namespace CodingTracker;
internal class Controller {
    private readonly UserInterface userInterface;
    private readonly CodingTrackerRepository codingTrackerRepository;
    private readonly UserValidation userValidation;

    public Controller(UserInterface userInterface, CodingTrackerRepository codingTrackerRepository, UserValidation userValidation) {
        this.userInterface = userInterface;
        this.codingTrackerRepository = codingTrackerRepository;
        this.userValidation = userValidation;
    }
    public void Run() {
        bool IsActive = true;

        while (IsActive) {
            
            userInterface.ClearScreen();
            userInterface.DisplayMenu();
            int choice = userInterface.GetUserChoice();
            ProcessUserChoice(choice);
        }
    }
    public void ProcessUserChoice(int choice) {
        switch (choice) {
            case 1:
                Console.WriteLine("test");
                

                var codingTracker = GetUserCodingTimes();
                AddCodingTracker(codingTracker);
                userInterface.PressToContinue();

                break;
            case 2:
                UpdateCodingTime();
                
                userInterface.PressToContinue();
                break;
            case 3:
                
                DeleteCodingTime();
                
                userInterface.PressToContinue();
                userInterface.ClearScreen();
                break;
            case 4:
                GetCodingTime();
                
                userInterface.PressToContinue();
                userInterface.ClearScreen();
                break;

            case 5:
                DisplayAllCodingTimes();
                userInterface.PressToContinue();
                userInterface.ClearScreen();
                break;
            case 6:
                userInterface.DisplayMessage("Exiting the application. Goodbye!");
                Environment.Exit(0);
                break;
            default:
                userInterface.DisplayMessage("Invalid choice. Please try again.");
                choice = userInterface.GetUserChoice();
                ProcessUserChoice(choice);

                break;
        }
    }

    private void GetCodingTime() {
        string actionToDo = "get";
        DisplayAllCodingTimes();

        var singleCodingTimeId = userInterface.GetSingleCodingTime(actionToDo);
        var codingTracker = codingTrackerRepository.GetCodingTimeById(singleCodingTimeId);
        userInterface.DisplaySingleCodingTime(codingTracker);
        
    }
    private void DisplayAllCodingTimes() {
        var codingTimesList = codingTrackerRepository.GetAllCodingTimes();
        userInterface.DisplayCodingTimes(codingTimesList);
    }

    private void DeleteCodingTime() {
        string actionToDo = "delete";

        var codingTracker = ValidIdLoop(actionToDo);
        codingTrackerRepository.DeleteCodingTime(codingTracker);

    }
    public CodingTracker ValidIdLoop(String actionToDo) {
        bool validId = false;
        DisplayAllCodingTimes();
        var singleCodingTimeId = userInterface.GetSingleCodingTime(actionToDo);
        var codingTracker = codingTrackerRepository.GetCodingTimeById(singleCodingTimeId);
        validId = userValidation.IdExists(codingTracker);
        Console.WriteLine(validId);

        if (!validId) {
            Console.Clear();
            Console.WriteLine("this is running regardless");
            Console.WriteLine(validId);
            return ValidIdLoop(actionToDo);
            
        }
        else {
            return codingTracker;
        }
    }

    private void UpdateCodingTime() {
        string actionToDo = "update";
        DisplayAllCodingTimes();
        var singleCodingTimeId = userInterface.GetSingleCodingTime(actionToDo);
        var codingTracker = codingTrackerRepository.GetCodingTimeById(singleCodingTimeId);
        var updatedCodingTracker = GetUserCodingTimes();
        codingTrackerRepository.UpdateCodingTime(codingTracker, updatedCodingTracker);
    }
    public DateTime GetDateForCodingTime() {
        DateTime dateTime;
        dateTime = userInterface.GetDateInput();
        DateTime temp = new(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        return temp;
    }
    
    public CodingTracker GetUserCodingTimes() {
        DateTime dateTime = GetDateForCodingTime();
        userInterface.DisplayMessage("Enter your start time");
        var startTime = userInterface.GetCodingTime(dateTime);
        userInterface.DisplayMessage("Enter your end time");
        var endTime = userInterface.GetCodingTime(dateTime);

        var codingTracker = CreateCodingTracker(startTime, endTime);

        return codingTracker;
    }

 

    private CodingTracker CreateCodingTracker(DateTime startTime, DateTime endTime) {
        CodingTracker codingTracker = new CodingTracker();
        var totalTime = codingTracker.CalculateTotalTime(startTime, endTime);
        codingTracker.StartTime = startTime.ToString();
        codingTracker.EndTime = endTime.ToString();
        
        codingTracker.codingHours = codingTracker.CalculateHours(totalTime);
        codingTracker.codingMinutes = codingTracker.CalculateMinutes(totalTime);
        codingTracker.codingSeconds = codingTracker.CalculateSeconds(totalTime);
        return codingTracker;


    }
    private void AddCodingTracker(CodingTracker codingTracker) {
        codingTrackerRepository.AddCodingTime(codingTracker);
    }
}

