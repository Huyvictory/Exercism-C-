using System;

class RemoteControlCar
{
    private int _traveledDistance = 0;
    private int _batteryRemaining = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_traveledDistance} meters";
    }

    public string BatteryDisplay()
    {
        return _batteryRemaining == 0 ? "Battery empty" : $"Battery at {_batteryRemaining}%";
    }

    public void Drive()
    {
        if (_batteryRemaining > 0)
        {
            _traveledDistance += 20;
            _batteryRemaining -= 1;
        }
    }
}
