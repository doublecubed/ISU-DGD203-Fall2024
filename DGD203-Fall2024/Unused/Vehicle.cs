namespace FirstGame;

public abstract class Vehicle
{
    public float Fuel { get; protected set; }  // percentage of fuel

    public void UseFuel(float fuel)
    {
        Fuel = Fuel - fuel < 0f ? 0f : Fuel - fuel;
    }
    
}