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
        Containers = new Dictionary<HashCode, Container>();
    }

    public void LoadContainer(Container container)
    {
        Containers.Add(container.SerialNumber.GetHashCode(), container);
    }

    /*public void LoadContainer(IEnumerable<Container> containers)
    {
        Containers.AddRange(containers);
    }

    public Container removeContainer(Container container)
    {
        Containers.Fin
    }*/
}