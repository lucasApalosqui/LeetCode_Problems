using System;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;



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
    public static string _osx = GetSystem(RuntimeInformation.OSDescription);
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location) => location switch
    {
        Location.NewYork => TransformToNewUtc(appointmentDateDescription, GetZone(location, _osx)),
        Location.Paris => TransformToNewUtc(appointmentDateDescription, GetZone(location, _osx)),
        Location.London => TransformToNewUtc(appointmentDateDescription, GetZone(location, _osx)),
        _ => DateTime.MinValue


    };

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
    {
        AlertLevel.Early => appointment.AddDays(-1),
        AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
        AlertLevel.Late => appointment.AddMinutes(-30),
        _ => appointment
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var dateParameter = dt.AddDays(-7);
        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(GetZone(location, _osx));
        return tzi.IsDaylightSavingTime(dateParameter) != tzi.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return DateTime.Parse(dtStr, LocationToCulture(location));

        }
        catch
        {
            return DateTime.MinValue;
        }
    }


    
    //Utils
    private static DateTime TransformToNewUtc(string date, string zone)
    {
        try
        {
            DateTime utc = DateTime.Parse(date);
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zone);

            return TimeZoneInfo.ConvertTimeToUtc(utc, tzi);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }

    private static string GetSystem(string osx) => osx switch
    {
        string os when os.Contains("Windows") => "Windows",
        string os when os.Contains("Linux") => "Linux",
        string os when os.Contains("OSX") => "OSX",
        _ => ""
    };

    private static string GetZone(Location location, string osx)
    {
        if (location == Location.NewYork)
        {
            return (osx == "Windows") ? "Eastern Standard Time" : "America/New_York";
        }
        if (location == Location.London)
        {
            return (osx == "Windows") ? "GMT Standard Time" : "Europe/London";
        }
        if (location == Location.Paris)
        {
            return (osx == "Windows") ? "W. Europe Standard Time" : "Europe/Paris";
        }
        else
            return "";
    }

    private static CultureInfo LocationToCulture(Location location)
    {
        string cultureId = string.Empty;
        switch (location)
        {
            case Location.NewYork:
                cultureId = "en-US";
                break;
            case Location.London:
                cultureId = "en-GB";
                break;
            case Location.Paris:
                cultureId = "fr-FR";
                break;
        }
        return new CultureInfo(cultureId);
    }
}
