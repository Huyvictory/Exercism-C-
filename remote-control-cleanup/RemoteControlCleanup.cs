public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;
    public CarTelemetry Telemetry;

    public RemoteControlCar() => Telemetry = new CarTelemetry(this);
    public string GetSpeed() => currentSpeed.ToString();
    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;
    private void SetSpeed(Speed speed) => currentSpeed = speed;

    public class CarTelemetry
    {
        private RemoteControlCar parent;
        public CarTelemetry(RemoteControlCar parent) => this.parent = parent;

        public void Calibrate()
        {
        }

        public bool SelfTest() => true;
        public void ShowSponsor(string sponsorName) => parent.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = (unitsString == "cps")
                ? SpeedUnits.CentimetersPerSecond
                : SpeedUnits.MetersPerSecond;
            parent.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    struct Speed
    {
        private decimal Amount { get; }
        private SpeedUnits SpeedUnits { get; }
        public Speed(decimal amount, SpeedUnits speedUnits) => (Amount, SpeedUnits) = (amount, speedUnits);

        public override string ToString() => (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            ? $"{Amount} centimeters per second"
            : $"{Amount} meters per second";
    }
}