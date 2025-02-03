using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }

    public void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive() =>
        DistanceTravelled += 10;

    public int CompareTo(object? obj)
    {
        ProductionRemoteControlCar otherCar = obj as ProductionRemoteControlCar;
        return (otherCar != null) ? this.NumberOfVictories.CompareTo(otherCar.NumberOfVictories) : throw new ArgumentException();
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive() =>
        DistanceTravelled += 20;
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) =>
        car.Drive();


    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2) =>
            (prc1.CompareTo(prc2) == 1) ? new List<ProductionRemoteControlCar> { prc2, prc1 } : new List<ProductionRemoteControlCar> { prc1, prc2 };

}
