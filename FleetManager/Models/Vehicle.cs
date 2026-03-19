using ReactiveUI;

namespace FleetManager.Models;

public class Vehicle : ReactiveObject
{
    private string _name;
    private string _licenceNumber;
    private int _fuelPercentage;
    private string _status;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    public string LicenceNumber
    {
        get => _licenceNumber;
        set => this.RaiseAndSetIfChanged(ref _licenceNumber, value);
    }
    
    public int FuelPercentage
    {
        get => _fuelPercentage;
        set => this.RaiseAndSetIfChanged(ref _fuelPercentage, value);
    }
    
    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }
}