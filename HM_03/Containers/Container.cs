using HM_03.Exceptions;

namespace HM_03.Containers;

public class Container : IContainer
{
    public static int ContainerCount { get; protected set; }
    
    public double Mass { get; protected set; }
    
    public double Height { get; protected set; } 
    
    public double TareWeight { get; protected set; }
    
    public double Depth { get; protected set; }
    
    public double MaxPayload { get; protected set; } 
    
    public string SerialNumber { get; protected set; } = string.Empty;

    public Container(double mass, double height, double tareWeight, double depth, double maxPayload)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }


    public virtual void Unload()
    {
        TareWeight = 0;
    }

    public virtual void Load(double mass, double multiplier = 1.0)
    {
        if (mass + Mass > MaxPayload * multiplier)
        {
            throw new OverfillException("Cannot be loaded. Cargo mass exceeds max payload");
        }
    }
    
    public override string ToString()
    {
        return $"Serial number: {SerialNumber}\n" +
               $"Cargo mass: {Mass} kg\n" +
               $"Height: {Height} cm\n" +
               $"Tare weight: {TareWeight} kg\n" +
               $"Depth: {Depth} cm\n" +
               $"Max payload: {MaxPayload} kg\n";
    }
}