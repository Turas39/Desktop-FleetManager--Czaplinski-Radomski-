using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using FleetManager.Models;
using FleetManager.Services;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();
    
    private readonly IVehicleService _vehicleService;
    
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }

    public MainWindowViewModel()
    {
        _vehicleService = new JsonVehicleService();
        
        SaveCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await _vehicleService.SaveVehiclesAsync(Vehicles.ToList());
        });
        
        LoadVehicles();
        
        
    }

    private async void LoadVehicles()
    {
        var list = await _vehicleService.LoadVehiclesAsync();

        foreach (var item in list)
            Vehicles.Add(item);
    }
    
    
    
}