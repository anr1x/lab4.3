using System;
using System.Collections.Generic;
using System.Threading;

// Клас, що представляє дорогу
public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int TrafficLevel { get; set; }

    public Road(double length, double width, int numberOfLanes)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        TrafficLevel = 0;
    }

    public void IncreaseTraffic()
    {
        // Логіка для збільшення рівня трафіку
        TrafficLevel++;
    }
}

// Інтерфейс для транспортного засобу
public interface IDriveable
{
    void Move();
    void Stop();
}

// Клас, що представляє транспортний засіб
public class Vehicle : IDriveable
{
    public string Type { get; set; }
    public double Speed { get; set; }
    public double Size { get; set; }

    public Vehicle(string type, double speed, double size)
    {
        Type = type;
        Speed = speed;
        Size = size;
    }

    public void Move()
    {
        Console.WriteLine($"{Type} is moving at {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Type} has stopped.");
    }
}

// Клас для імітації руху транспортних засобів на дорозі
public class TrafficSimulator
{
    public void SimulateTraffic(Road road, List<Vehicle> vehicles)
    {
        Console.WriteLine($"Simulation on {road.Length} km road with {road.NumberOfLanes} lanes.");

        while (road.TrafficLevel < 10)
        {
            road.IncreaseTraffic();

            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
                Thread.Sleep(100); // Затримка для імітації руху
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Road cityRoad = new Road(10, 3, 2);
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle("Car", 60, 2),
            new Vehicle("Truck", 40, 3),
            new Vehicle("Bus", 50, 3),
        };

        TrafficSimulator simulator = new TrafficSimulator();
        simulator.SimulateTraffic(cityRoad, vehicles);
    }
}
