using System.Security.Cryptography.X509Certificates;

static class AssemblyLine
{
    public static readonly int carsPerHour = 221;

    public static double SuccessRate(int speed)
    {
        if (speed == 0)
            return 0;
        else if (speed >= 1 && speed <= 4)
            return 1;
        else if (speed >= 5 && speed <= 8)
            return 0.90;
        else if (speed == 9)
            return 0.80;
        else
            return 0.77;
    }

    public static double ProductionRatePerHour(int speed)
    {
        return (carsPerHour * speed) * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}