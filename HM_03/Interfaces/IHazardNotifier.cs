namespace HM_03.Interfaces;

public interface IHazardNotifier
{
    
    void SendHazardNotification(string message, string serialNumber);
}