using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FleetManager.Services;

namespace FleetManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<VehicleItemViewModel> Vehicles { get; } = new();

    public MainWindowViewModel()
    {
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var service = new JsonVehicleService();
        var data = await service.GetVehiclesAsync();

        foreach (var vehicle in data)
        {
            Vehicles.Add(new VehicleItemViewModel(vehicle));
        }
    }
}