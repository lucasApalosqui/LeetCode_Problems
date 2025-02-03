using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return $"{checked(@base * multiplier)}";
        }
        catch  
        {
            return ("*** Too Big ***");
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
       return float.IsFinite(@base * multiplier) ? $"{@base * multiplier}" : "*** Too Big ***";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return $"{checked(salaryBase * multiplier)}";
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
