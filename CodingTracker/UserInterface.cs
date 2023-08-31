using ConsoleTableExt;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Globalization;
using System.Transactions;

namespace CodingTracker;
internal class UserInterface {

    private readonly UserValidation userValidation;

    public UserInterface(UserValidation userValidation) {
        this.userValidation = userValidation;
    }
    public void DisplayMenu() {
        Console.WriteLine("Please select and option:");
        Console.WriteLine("1: Add Coding Time");
        Console.WriteLine("2: Update Coding Time");
        Console.WriteLine("3: Delete Coding Time");
        Console.WriteLine("4: Get A Coding Time");
        Console.WriteLine("5: Get All Coding Times");
        Console.WriteLine("6: Exit");
        


    }

    public int GetUserChoice() {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.WriteLine("Enter your choice");

        }
        return choice;
    }


    public void DisplayMessage(string message) {
        Console.WriteLine(message);
    }
    public void ClearScreen() {
        Console.Clear();
    }

    public DateTime GetCodingTime(DateTime dateTime) {
        DateTime codingTimes;

        Console.WriteLine("\n\nPlease insert the time: (Format: H:mm:ss). Type 0 to return to main manu.\n\n");


        string dates = Console.ReadLine();
        if (dates == "0") return default;
        while (!DateTime.TryParseExact(dates, "H:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out codingTimes)) {
            Console.WriteLine("Invalid Time (Format: hours:minutes:seconds: Type 0 to return to main menu or try again: \n\n");
            dates = Console.ReadLine();
            if (dates == "0") {
                
                return default;
            }
   
        }
   
        DateTime actualTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, codingTimes.Hour, codingTimes.Minute, codingTimes.Second);

        
        return actualTime;


    }

    internal DateTime GetDateInput() {
        DateTime dateTime;
        Console.WriteLine("\n\nPlease insert the date: (Format: dd/mm/yy). Type 0 to return to main manu.\n\n");

        string dateInput = Console.ReadLine();

        if (dateInput == "0") return default;

        while (!DateTime.TryParseExact(dateInput, "dd/MM/yy", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime)) {
            Console.WriteLine("\n\nInvalid date. (Format: dd/mm/yy). Type 0 to return to main menu or try again:\n\n");
            dateInput = Console.ReadLine();
            if (dateInput == "0") {
                
                return default;
                
            }
                
        }

    

    

        return dateTime;
    }

    internal void DisplayCodingTimes(List<CodingTracker> codingTimes) {
        
        ConsoleTableBuilder
            .From(codingTimes)
            .ExportAndWriteLine();

    }
    internal int GetSingleCodingTime(string action) {
        Console.WriteLine($"Please type the id of the coding time you would like to {action}");
        
        int id = userValidation.ParseId();
        

        
        return id;
    }
    internal void DisplaySingleCodingTime(CodingTracker codingTime) {
        var codingTimeList = new List<CodingTracker>() { codingTime };
        ConsoleTableBuilder
           .From(codingTimeList)
           .ExportAndWriteLine();
        
        

    }
    internal void PressToContinue() {
        Console.WriteLine("Please press any key to continue");
        Console.ReadKey();
    }
}

    
