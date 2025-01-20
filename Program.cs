using System;
using System.Globalization;

Console.WriteLine(Appointment.Description(new DateTime(2019, 07, 25, 13, 45, 0)));
var etste = Appointment.Description(new DateTime(2019, 07, 25, 13, 45, 0)).Replace('\u202F', ' ');
Console.WriteLine(etste);


static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        if(appointmentDateDescription.Contains('/'))
            if (appointmentDateDescription.Length != 19)
                return DateTime.ParseExact(appointmentDateDescription, "M/d/yyyy HH:mm:ss", null);
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        if(appointmentDate <  DateTime.Now)
            return true;
        return false;

    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if(appointmentDate.Hour >= 12 && appointmentDate.Hour < 18)
            return true;
        return false;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString("M/d/yyyy hh:mm:ss tt")}PM.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
    }
}
