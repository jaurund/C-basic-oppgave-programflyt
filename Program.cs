using System;
using System.IO;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        // Reader that simulates Arduino data from "arduino.txt"
        SimulatedSensorReader reader = new SimulatedSensorReader("arduino.txt");
        TemperatureData temps = reader.ReadFakeSerialLine();

        TemperatureRanges ranges = new TemperatureRanges(
            freezerMin: -25, freezerMax: -18,
            fridgeMin: 2, fridgeMax: 8,
            ambientMin: 15, ambientMax: 25
        );

        if (temps != null)
        {
            Console.WriteLine($"Read: Freezer={temps.FreezerTemp}°C, Fridge={temps.FridgeTemp}°C, Ambient={temps.AmbientTemp}°C");
            TemperatureChecker checker = new TemperatureChecker();
            checker.CheckTemperatures(temps, ranges);
        }
    }
}



/*{
    // Create an instance of your data class with some example temps
    TemperatureData storeTemps = new TemperatureData(freezerTemp: -19, fridgeTemp: 6, ambientTemp: 26);

    // Create the checker
    TemperatureChecker checker = new TemperatureChecker();

    // Run the check
    checker.CheckTemperatures(storeTemps);
}
}*/

