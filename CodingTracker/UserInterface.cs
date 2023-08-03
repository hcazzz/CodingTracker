﻿using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Globalization;
using System.Transactions;

namespace CodingTracker;
public class UserInterface {

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
            Console.Write("Enter your choice");

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
        if (dates == "0") DisplayMenu();
        while (!DateTime.TryParseExact(dates, "H:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out codingTimes)) {
            Console.WriteLine("Invalid Time (Format: hours:minutes:seconds: \n");
            dates = Console.ReadLine();

        }
        
        DateTime actualTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, codingTimes.Hour, codingTimes.Minute, codingTimes.Second);

        Console.WriteLine(actualTime.Day);
        Console.WriteLine(actualTime.Minute);
        return actualTime;
        

    }

    public DateTime GetDateInput() {
        DateTime dateTime;
        Console.WriteLine("\n\nPlease insert the date: (Format: dd/mm/yy). Type 0 to return to main manu.\n\n");

        string dateInput = Console.ReadLine();

        if (dateInput == "0") DisplayMenu();

        while (!DateTime.TryParseExact(dateInput, "dd/MM/yy", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime)) {
            Console.WriteLine("\n\nInvalid date. (Format: dd-mm-yy). Type 0 to return to main manu or try again:\n\n");
            dateInput = Console.ReadLine();
        }

        return dateTime;
    }

    internal void DisplayCodingTimes(List<CodingTracker> codingTimes) {
        Console.Clear();
        foreach (var codingTracker in codingTimes) {
            Console.WriteLine(codingTracker.codingHours);
        }
    }
}
//after your break make it to where you only do GetDateInput() once, call GetDateInput in the controller pass the DateTime variable into the GetCodingTime() and set the day into the DateTime object in there