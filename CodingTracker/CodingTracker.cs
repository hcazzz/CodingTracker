
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodingTracker;
public class CodingTracker {

    public int Id { get; set; }

    [Required]
    public string StartTime { get; set; }
    [Required]
    public string EndTime { get; set; }

    public int codingHours { get; set; }
    public int codingMinutes { get; set; }
    public int codingSeconds { get; set; }


    //violates srp so eventually condense this into its own class called CodingTimeCalculator
    public int CalculateHours(TimeSpan totalTime) {
        int totalHours = (int)totalTime.TotalHours;




        return totalHours;
    }
    public int CalculateMinutes(TimeSpan totalTime) {
        int totalMinutes = totalTime.Minutes;
        return totalMinutes;

    }
    public int CalculateSeconds(TimeSpan totalTime) {
        int totalSeconds = totalTime.Seconds;
        return totalSeconds;
    }

    public TimeSpan CalculateTotalTime(DateTime startTime, DateTime endTime) {
        var totalTime = endTime - startTime;
        return totalTime;
    }



   
}