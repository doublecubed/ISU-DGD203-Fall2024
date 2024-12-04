namespace FirstGame;

public abstract class Engine : IEngine
{
    protected float _hp;
    protected float _fuelConsumptionRate;
	
    public bool Running {get; protected set;}
    
    public virtual void Start()
    {
        Running = true;
        Console.WriteLine("The engine starts running");
    }
	
    public void Stop()
    {
        Running = false;
    }

    public bool IsRunning()
    {
        return Running;
    }
}