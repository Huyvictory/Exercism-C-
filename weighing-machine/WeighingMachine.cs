using System;

class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get; }

    private double _weight;

    // TODO: define the 'Weight' property
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative");
            }

            _weight = value;
        }
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    private string FormatDouble(double value)
    {
        var formatString = $"F{Precision}";
        return value.ToString(formatString);
    }

    // TODO: define the 'DisplayWeight'
    public string DisplayWeight => $"{FormatDouble(Weight - TareAdjustment)} kg";

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5.0;
}