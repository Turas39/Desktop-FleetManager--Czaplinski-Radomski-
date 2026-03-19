using ReactiveUI;

namespace FleetManager.Models;

public class Vehicle : ReactiveObject
{
    private string _name;
    private string _licenseNumber;
    private int _fuelPercentage;
    private string _status;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    public string LicenseNumber
    {
        get => _licenseNumber;
        set => this.RaiseAndSetIfChanged(ref _licenseNumber, value);
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