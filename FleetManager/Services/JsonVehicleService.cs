using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FleetManager.Models;

namespace FleetManager.Services;

public class JsonVehicleService : IVehicleService
{
    private readonly string _filePath = "Assets/vehicles.json";

    public async Task<List<Vehicle>> LoadVehiclesAsync()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return new List<Vehicle>();
            }

            string json = await File.ReadAllTextAsync(_filePath);
            var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);
            return vehicles ?? new List<Vehicle>();
        }
        catch
        {
            return new List<Vehicle>();
        }
    }
}