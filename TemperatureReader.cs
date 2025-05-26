using System;
using System.IO;
using System.Globalization;

// Reads temperatures from file, and throws errors to the console if the data is invalid or corrupted.

public class TemperatureReader
{
    public TemperatureData? ReadFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        try
        {
            double freezer = double.Parse(lines[0]);
            double fridge = double.Parse(lines[1]);
            double ambient = double.Parse(lines[2]);

            return new TemperatureData(freezer, fridge, ambient);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid temperature data. Check sensor.");
            return null;
        }
    }
}

public class SimulatedSensorReader
{
    private string _filePath;

    public SimulatedSensorReader(string filePath)
    {
        _filePath = filePath;
    }

    public TemperatureData? ReadFakeSerialLine()
    {
        try
        {
            string line = File.ReadAllText(_filePath);
            string[] parts = line.Split(',');
            if (parts.Length != 3)
            {
                Console.WriteLine(
                    "Corrupted data from sensor(s): wrong format. Check input data or sensor(s)."
                );
                return null;
            }

            double freezer = double.Parse(parts[0], CultureInfo.InvariantCulture);
            double fridge = double.Parse(parts[1], CultureInfo.InvariantCulture);
            double ambient = double.Parse(parts[2], CultureInfo.InvariantCulture);

            return new TemperatureData(freezer, fridge, ambient);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Sensor data file not found: " + ex.Message);
            return null;
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine("Sensor data missing or incomplete: " + ex.Message);
            return null;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Data format error: " + ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error (" + ex.GetType().Name + "): " + ex.Message);
            return null;
        }
    }
}
