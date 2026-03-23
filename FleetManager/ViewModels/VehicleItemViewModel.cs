// (ViewModel dla UserControl)

using System.Collections.ObjectModel;
using System.Reactive;
using FleetManager.Models;
using ReactiveUI;

namespace FleetManager.ViewModels;

public class VehicleItemViewModel : ViewModelBase
{
    public Vehicle Model { get; }

    public ReactiveCommand<VehicleStatus, Unit> ChangeStatusCommand { get; }

    public VehicleItemViewModel(Vehicle vehicle)
    {
        Model = vehicle;

        ChangeStatusCommand = ReactiveCommand.Create<VehicleStatus>(status =>
        {
            Model.Status = status;
        });
    }
}