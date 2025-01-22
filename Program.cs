using System;

class RemoteControlCar
{
    private int _speed, _batteryDrain;
    private int _battery = 100;
    private int _meters = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }


    public bool BatteryDrained()
    {
        return (_battery <= 0 || _battery - _batteryDrain < 0) ? true : false;
    }

    public int DistanceDriven()
    {
        return _meters;
    }

    public int MaxDistance()
    {
        var battery = 100;
        var meters = 0;
        while (!(battery - _batteryDrain < 0))
        {
            meters += _speed;
            battery -= _batteryDrain;
        }

        return meters;
    }

    public void Drive()
    {
        if (!(_battery - _batteryDrain < 0))
        {
            _meters += _speed;
            _battery -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int _distance;
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        return (car.MaxDistance() >= _distance) ? true : false;
    }
}
