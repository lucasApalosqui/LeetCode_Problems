var car = RemoteControlCar.Buy();
car.Drive();
car.Drive();
car.BatteryDisplay();

class RemoteControlCar
{
    private int _battery, _distance;

    public RemoteControlCar()
    {
        _battery = 100;
        _distance = 0;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distance} meters";
    }

    public string BatteryDisplay()
    {
        if (_battery <= 0)
            return $"Battery at {_battery}%";
        return "Battery empty";
    }

    public void Drive()
    {
        _battery -= 1;

        if (_battery != 0)
            _distance += 20;
    }
}