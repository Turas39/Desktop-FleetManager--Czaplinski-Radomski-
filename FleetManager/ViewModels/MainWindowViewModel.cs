using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using FleetManager.Models;
using FleetManager.Services;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();
    
    private readonly JsonVehicleService _vehicleService;

    public MainWindowViewModel()
    {
        _vehicleService = new JsonVehicleService();
        
        _ = LoadVehicles();
        
    }

    private async Task LoadVehicles()
    {
        var vehicles = await _vehicleService.LoadVehiclesAsync();
        Vehicles.Clear();

        foreach (var v in vehicles)
        {
            Vehicles.Add(new VehicleItemViewModel(v));
        }
    }
    
    
    
}