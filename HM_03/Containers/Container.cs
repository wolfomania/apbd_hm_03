using HM_03.Exceptions;
using HM_03.Interfaces;

namespace HM_03.Containers;

public abstract class Container : IContainer
{
    public static int ContainerCount { get; protected set; } = 1;
    
    public double Mass { get; protected set; }
    
    public double Height { get; protected set; } 
    
    public double TareWeight { get; protected set; }
    
    public double Depth { get; protected set; }
    
    public double MaxPayload { get; protected set; } 
    
    public string SerialNumber { get; protected set; }

    public Container(double height, double tareWeight, double depth, double maxPayload)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
        SerialNumber = "KON-" + GetContainerType() + "-" + ContainerCount++;
    }


    public virtual void Unload() {
        TareWeight = 0;
    }

    public virtual void Load(double mass, double multiplier = 1.0) {
        if (mass + Mass > MaxPayload * multiplier)
        {
            throw new OverfillException("Cannot be loaded. Cargo mass exceeds max payload");
        }
        Mass += mass;
    }

    public double GetFullWeight()
    {
        return Mass + TareWeight;
    }

    public virtual string GetContainerType() {
        return "C";
    }
    
    public override string ToString() {
        return $"Serial number: {SerialNumber}\n" +
               $"\tCargo mass: {Mass} kg\n" +
               $"\tHeight: {Height} cm\n" +
               $"\tTare weight: {TareWeight} kg\n" +
               $"\tDepth: {Depth} cm\n" +
               $"\tMax payload: {MaxPayload} kg\n";
    }
}