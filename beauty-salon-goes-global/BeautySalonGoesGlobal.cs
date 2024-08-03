using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace BeautySalonGoesGlobal;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);
    }

    private static DateTime ConvertToUtcFromRegion(string dateTimeString, string region)
    {
        // Parse the string into a DateTime object
        var localDateTime =
            DateTime.Parse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.None);

        // Retrieve the time zone information
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(region);

        // Convert the DateTime to UTC
        var utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, timeZone);

        return utcDateTime;
    }


    private static string GetRegion(Location location)
    {
        var currentOs = RuntimeInformation.OSDescription;

        return location switch
        {
            Location.NewYork => currentOs.Contains("Windows") ? "Eastern Standard Time" : "America/New_York",
            Location.London => currentOs.Contains("Windows") ? "GMT Standard Time" : "Europe/London",
            Location.Paris => currentOs.Contains("Windows") ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentException("Invalid location")
        };
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var region = GetRegion(location);

        return ConvertToUtcFromRegion(appointmentDateDescription, region);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var alertTime = alertLevel switch
        {
            AlertLevel.Early => appointment.Subtract(TimeSpan.FromDays(1)),
            AlertLevel.Standard => new DateTime(appointment.Year, appointment.Month, appointment.Day, 14, 15, 0),
            AlertLevel.Late => appointment.Subtract(TimeSpan.FromMinutes(30)),
            _ => throw new ArgumentException("Invalid alert level")
        };

        return alertTime;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var region = GetRegion(location);

        var dateTimeWeekAgo = dt.AddDays(-7);

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(region);

        return timeZone.IsDaylightSavingTime(dateTimeWeekAgo) != timeZone.IsDaylightSavingTime(dt);
    }

    private static (CultureInfo cultrInfo, string dateTimeFormat) GetDateTimeFormat(string region)
    {
        var cultureInfo = region switch
        {
            "Eastern Standard Time" or "America/New_York" =>
                // CultureInfo for the USA Eastern Time (using en-US)
                (new CultureInfo("en-US"), new CultureInfo("en-US").DateTimeFormat.FullDateTimePattern),
            "GMT Standard Time" or "Europe/London" =>
                // CultureInfo for London (using en-GB)
                (new CultureInfo("en-GB"), new CultureInfo("en-GB").DateTimeFormat.FullDateTimePattern),
            "W. Europe Standard Time" or "Europe/Paris" =>
                // CultureInfo for Paris (using fr-FR)
                (new CultureInfo("fr-FR"), new CultureInfo("fr-FR").DateTimeFormat.FullDateTimePattern),
            _ => throw new ArgumentException("Unsupported or invalid region")
        };


        return cultureInfo;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var region = GetRegion(location);
        var formatTimeRegion = GetDateTimeFormat(region);

        return DateTime.TryParse(dtStr, formatTimeRegion.cultrInfo, DateTimeStyles.None, out var localDateTime)
            ? localDateTime
            : new DateTime(1, 1, 1, 0, 0, 0);
    }
}