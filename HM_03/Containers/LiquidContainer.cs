using HM_03.Exceptions;
using HM_03.Interfaces;

namespace HM_03.Containers;

public class LiquidContainer : Container, IHazardNotifier {
    public bool Hazardous { get; set; }
    
    public LiquidContainer(double mass, double height, double tareWeight, double depth, double maxPayload, bool hazardous) 
        : base( height, tareWeight, depth, maxPayload)
    {
        Mass = 0;
        Hazardous = hazardous;
        base.Load(mass);
    }

    public override void Load(double mass, double multiplier = 1) {
        try {
                base.Load(mass, Hazardous ? 0.5 : 0.9);
        }
        catch (OverfillException)
        {
            SendHazardNotification(
                Hazardous
                    ? "You are trying to fill liquid container with hazardous cargo over 50%"
                    : "You are trying to fill liquid container with non-hazardous cargo over 90%",
                SerialNumber
            );
        }
    }

    public void SendHazardNotification(string message, string serialNumber)
    {
        Console.WriteLine("Dangerous situation occurred: \n" +
                          message + "\nOn the container: " + serialNumber);
    }

    public override string GetContainerType() 
    {
        return "L";
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\tHazardous: {Hazardous}\n";
    }
}