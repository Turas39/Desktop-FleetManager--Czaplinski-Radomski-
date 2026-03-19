using System;
using System.Collections.ObjectModel;
using FleetManager.Models;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();
    
    private readonly IVehicleService _vehicleService;

    public MainWindowViewModel()
    {
        _vehicleService = new JsonVehicleService();
        LoadVehicles();
    }

    private async void LoadVehicles()
    {
        var list = await _vehicleService.LoadVehiclesAsync();

        foreach (var item in list)
            Vehicles.Add(item);
           
        
    }
    
    
}