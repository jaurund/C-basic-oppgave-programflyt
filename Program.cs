using System;
using System.Globalization;

// main method to run program and load ranges from .txt

public class Program
{
    public static void Main()
    {
        // Reader that simulates Arduino data from "arduino.txt"
        SimulatedSensorReader reader = new SimulatedSensorReader("arduino.txt");
        TemperatureData temps = reader.ReadFakeSerialLine();

        // Load temperature ranges from file tempRanges.txt
        TemperatureRanges? ranges = TemperatureRangeLoader.LoadFromFile("tempRanges.txt");

        if (temps != null && ranges != null)
        {
            Console.WriteLine(
                $"Read: Freezer={temps.FreezerTemp}°C, Fridge={temps.FridgeTemp}°C, Ambient={temps.AmbientTemp}°C"
            );
            TemperatureChecker checker = new TemperatureChecker();
            checker.CheckTemperatures(temps, ranges);
        }
    }
}

public static class TemperatureRangeLoader
{
    public static TemperatureRanges? LoadFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length != 3)
            {
                Console.WriteLine("Error: Range file must contain exactly 3 lines.");
                return null;
            }

            string[] freezerParts = lines[0].Split(',');
            string[] fridgeParts = lines[1].Split(',');
            string[] ambientParts = lines[2].Split(',');

            double freezerMin = double.Parse(freezerParts[0], CultureInfo.InvariantCulture);
            double freezerMax = double.Parse(freezerParts[1], CultureInfo.InvariantCulture);

            double fridgeMin = double.Parse(fridgeParts[0], CultureInfo.InvariantCulture);
            double fridgeMax = double.Parse(fridgeParts[1], CultureInfo.InvariantCulture);

            double ambientMin = double.Parse(ambientParts[0], CultureInfo.InvariantCulture);
            double ambientMax = double.Parse(ambientParts[1], CultureInfo.InvariantCulture);

            return new TemperatureRanges(freezerMin, freezerMax, fridgeMin, fridgeMax, ambientMin, ambientMax);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load temperature ranges: " + ex.Message);
            return null;
        }
    }
}
