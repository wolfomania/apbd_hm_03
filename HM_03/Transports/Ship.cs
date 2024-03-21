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

    public void LoadContainer(Container container)
    {
        string number = container.SerialNumber;
        Containers.Add(Int32.Parse(number.Substring(6)), container);
    }

    public void LoadContainer(IEnumerable<Container> containers)
    {
        foreach (var VARIABLE in containers)
        {
            LoadContainer(VARIABLE);
        }
    }

    public Container removeContainer(Container container)
    {
        var number = container.SerialNumber;
        Containers.Remove(Int32.Parse(number.Substring(6)));
        return container;
    }

    public Container replace(int num, Container container)
    {
        Container temp = Containers[num];
        LoadContainer(container);
        return temp;
    }
}