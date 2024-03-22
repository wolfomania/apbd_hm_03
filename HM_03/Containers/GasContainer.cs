using HM_03.Exceptions;
using HM_03.Interfaces;

namespace HM_03.Containers;

public class GasContainer : Container, IHazardNotifier
{

    
    public double Pressure { get; set; }

    public GasContainer(double mass, double height, double tareWeight, double depth, double maxPayload, double pressure) 
        : base(height, tareWeight, depth, maxPayload)
    {
        Mass = 0;
        Pressure = pressure;
        base.Load(mass);
    }

    public override void Unload()
    {
        Mass = Mass * 0.05;
    }
    

    public void SendHazardNotification(string message, string serialNumber)
    {
        Console.WriteLine("Dangerous situation occurred: \n" +
                          message + "\nOn the container: " + serialNumber);
    }

    public override string GetContainerType()
    {
        return "G";
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\tPressure: {Pressure} atmospheres";
    }
}