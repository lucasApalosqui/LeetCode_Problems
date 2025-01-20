using System;


Console.WriteLine(Badge.Print(null, "Amare Osei", null));
static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        if(id != null && department != null)
            return $"[{id}] - {name} - {department.ToUpper()}";

        if (id == null && department != null)
            return $"{name} - {department.ToUpper()}";

        if (department == null)
            department = "OWNER";

        return (id == null) ? $"{name} - {department.ToUpper()}" : $"[{id}] - {name} - {department.ToUpper()}";

    }
}