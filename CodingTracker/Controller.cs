namespace CodingTracker;
internal class Controller {
    private readonly UserInterface userInterface;
    private readonly CodingTrackerRepository codingTrackerRepository;

    public Controller(UserInterface userInterface, CodingTrackerRepository codingTrackerRepository) {
        this.userInterface = userInterface;
        this.codingTrackerRepository = codingTrackerRepository;
    }
    public void Run() {
        userInterface.DisplayMenu();
        int choice = userInterface.GetUserChoice();
        ProcessUserChoice(choice);
    }
    public void ProcessUserChoice(int choice) {
        switch (choice) {
            case 1:
                Console.WriteLine("test");
                

                var codingTracker = GetUserCodingTimes();
                AddCodingTracker(codingTracker);

                break;
            case 2:
                UpdateCodingTime();
                userInterface.ClearScreen();
                break;
            case 3:
                DeleteCodingTime();
                userInterface.ClearScreen();
                break;
            case 4:
                GetCodingTime();
                userInterface.ClearScreen();
                break;

            case 5:
                var codingTimes = codingTrackerRepository.GetAllCodingTimes();
                userInterface.DisplayCodingTimes(codingTimes);
                break;
            case 6:
                userInterface.DisplayMessage("Exiting the application. Goodbye!");
                //Environment.Exit(0);
                break;
            default:
                userInterface.DisplayMessage("Invalid choice. Please try again.");
                userInterface.GetUserChoice();
                break;
        }
    }

    private void GetCodingTime() {
        throw new NotImplementedException();
    }

    private void DeleteCodingTime() {
        throw new NotImplementedException();
    }

    private void UpdateCodingTime() {
        throw new NotImplementedException();
    }
    public DateTime GetDate() {
        DateTime dateTime;
        dateTime = userInterface.GetDateInput();
        DateTime temp = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        return temp;
    }
    
    public CodingTracker GetUserCodingTimes() {
        DateTime dateTime = GetDate();
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
