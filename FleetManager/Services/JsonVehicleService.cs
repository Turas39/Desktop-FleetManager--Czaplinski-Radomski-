using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    
    private readonly string VehiclesPath = Path.Combine(AppContext.BaseDirectory, "Assets", "vehicles.json");

    public async Task<List<Vehicle>> LoadVehiclesAsync()
    {
        try
        {
            if (!File.Exists(VehiclesPath))
                return new List<Vehicle>();
            
            var json = await File.ReadAllTextAsync(VehiclesPath);
            return JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
        }
        catch
        {
            return new List<Vehicle>();
        }
        
    }
}