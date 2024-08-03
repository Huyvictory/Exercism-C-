using System;

class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    private int _speed;
    private int _batteryDrain;
    private int _batteryRemaining = 100;
    private int _distanceDriven = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _batteryRemaining < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if (_batteryRemaining >= _batteryDrain)
        {
            _distanceDriven += _speed;
            _batteryRemaining -= _batteryDrain;
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

    // TODO: define the constructor for the 'RaceTrack' class

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < _distance)
        {
            if (car.BatteryDrained())
            {
                return false;
            }
            car.Drive();
        }

        return true;
    }
}
