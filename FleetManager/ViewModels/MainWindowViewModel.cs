using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IVehicleService _vehicleService;
    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();

    public MainWindowViewModel()
    {
        _vehicleService = new JsonVehicleService();
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var data = await _vehicleService.LoadVehiclesAsync();

        foreach (var vehicle in data)
        {
            Vehicles.Add(new VehicleItemViewModel(vehicle));
        }
    }
}