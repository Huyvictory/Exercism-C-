using System;
using System.Globalization;


static class Appointment
{
    // Method to split time and return a tuple
    private static (int hour, int minute, int second) SplitTime(string timePart)
    {
        string[] timeParts = timePart.Split(':');
        int hour = int.Parse(timeParts[0]);
        int minute = int.Parse(timeParts[1]);
        int second = int.Parse(timeParts[2]);
        return (hour, minute, second);
    }

    public static DateTime Schedule(string appointmentDateDescription)
    {
        string[] formats =
        [
            "MMMM d, yyyy HH:mm:ss", // Format for "June 3, 2019 11:30:00"
            "dddd, MMMM d, yyyy HH:mm:ss", // Format for "Thursday, December 5, 2019 09:00:00"
            "M/d/yyyy HH:mm:ss" // Format for "7/25/2019 13:45:00"
        ];

        DateTime.TryParseExact(
            appointmentDateDescription,
            formats,
            null,
            DateTimeStyles.None,
            out DateTime parsedResult
        );

        return new DateTime(
            parsedResult.Year,
            parsedResult.Month,
            parsedResult.Day,
            parsedResult.Hour,
            parsedResult.Minute,
            parsedResult.Second
        );
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var (hour, _, _) = SplitTime(appointmentDate.ToString("HH:mm:ss"));

        return hour is >= 12 and < 18;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
    }
}