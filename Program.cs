using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        // Reader that simulates Arduino data from "arduino.txt"
        SimulatedSensorReader reader = new SimulatedSensorReader("arduino.txt");
        TemperatureData temps = reader.ReadFakeSerialLine();

        TemperatureRanges ranges = new TemperatureRanges(
            freezerMin: -25,
            freezerMax: -18,
            fridgeMin: 2,
            fridgeMax: 8,
            ambientMin: 15,
            ambientMax: 25
        );

        if (temps != null)
        {
            Console.WriteLine(
                $"Read: Freezer={temps.FreezerTemp}°C, Fridge={temps.FridgeTemp}°C, Ambient={temps.AmbientTemp}°C"
            );
            TemperatureChecker checker = new TemperatureChecker();
            checker.CheckTemperatures(temps, ranges);
        }
    }
}
