namespace FirstGame.Engines;

public class ElectricEngine : Engine
{
    public override void Start()
    {
        base.Start();
        Console.WriteLine("The engine does not make any sound");
        CheckBatteryStatus();
    }

    private void CheckBatteryStatus()
    {
        Console.WriteLine("The battery is fine");
    }
}