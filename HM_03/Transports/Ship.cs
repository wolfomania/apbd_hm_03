using System.Collections.ObjectModel;
using HM_03.Containers;

namespace HM_03.Transports;

public class Ship
{

    public Dictionary<int, Container> Containers { get; set; }

    public double MaxSpeed { get; set; }

    private int MaxNumOfContainers { get; set; }

    public double MaxMass { get; set; }

    public Ship(double maxSpeed, int maxNumOfContainers, double maxMass)
    {
        MaxSpeed = maxSpeed;
        MaxNumOfContainers = maxNumOfContainers;
        MaxMass = maxMass;
        Containers = new Dictionary<int, Container>(maxNumOfContainers);
    }

    public bool LoadContainer(Container container)
    {
        if (GetCargoWeight() + container.GetFullWeight() > MaxMass * 1000)
        {
            Console.WriteLine("Can't load container on board. Mass overload.");
            return false;
        }
        if (Containers.Count + 1 > MaxNumOfContainers)
        {
            Console.WriteLine("Can't load container on board. Max num of containers already loaded.");
            return false;
        }
        
        var number = container.SerialNumber;
        if (Containers.TryAdd(Int32.Parse(number.Substring(6)), container))
            return true;
        Console.WriteLine($"Container: {container.SerialNumber}, already on this ship");
        return false;
    }

    public bool LoadContainers(IEnumerable<Container> containers)
    {
        if (containers.All(LoadContainer)) return true;
        Console.WriteLine("Ship is fully loaded.");
        return false;

    }

    public Container RemoveContainer(Container container)
    {
        var number = container.SerialNumber;
        Containers.Remove(Int32.Parse(number.Substring(6)));
        return container;
    }

    public Container Replace(int num, Container container)
    {
        Container temp = Containers[num];
        LoadContainer(container);
        return temp;
    }

    public bool TransferContainerTo(Container container, Ship ship)
    {
        if (ship.LoadContainer(container)) return true;
        LoadContainer(container);
        return false;

    }

    public double GetCargoWeight()
    {
        double sum = 0;
        foreach (var variable in Containers.Values)
        {
            sum += variable.Mass;
        }

        return sum;
    }

    public void DisplayAllContainers()
    {
        foreach (var variable in Containers.Values)
        {
            Console.WriteLine(variable);
        }
    }

    public override string ToString()
    {
        return "Ship description:\n" +
               $"\tMax speed: {MaxSpeed} knots\n" +
               $"\tContainers on board: {Containers.Count} / {MaxNumOfContainers}\n" +
               $"\tCargo weight on board: {GetCargoWeight()} / {MaxMass} tons\n";
    }
}