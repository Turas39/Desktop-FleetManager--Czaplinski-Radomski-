using System.Reactive;
using FleetManager.Models;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    public Vehicle Model { get; }
    public ReactiveCommand<VehicleStatus, Unit> ChangeStatusCommand { get; }
    public ReactiveCommand<Unit, Unit> RefuelCommand { get; }

    public VehicleItemViewModel(Vehicle vehicle)
    {
        Model = vehicle;

        ChangeStatusCommand = ReactiveCommand.Create<VehicleStatus>(newStatus =>
        {
            if (newStatus == VehicleStatus.InRoute)
            {
                if (Model.FuelLevel < 15.0 || Model.Status == VehicleStatus.Service)
                {
                    return;
                }
            }
            Model.Status = newStatus;
        });

        RefuelCommand = ReactiveCommand.Create(() =>
        {
            if (Model.Status == VehicleStatus.InRoute)
            {
                return;
            }
            Model.FuelLevel = 100.0;
        });
    }
}