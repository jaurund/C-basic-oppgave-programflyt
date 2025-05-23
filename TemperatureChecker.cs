public class TemperatureChecker
{
    public void CheckTemperatures(TemperatureData temps, TemperatureRanges ranges)
    {
        // Freezer
        if (temps.FreezerTemp < ranges.FreezerMin)
            Console.WriteLine("Freezer temperature is TOO LOW!");
        else if (temps.FreezerTemp > ranges.FreezerMax)
            Console.WriteLine("Freezer temperature is TOO HIGH!");
        else
            Console.WriteLine("Freezer temperature is OK.");

        // Fridge
        if (temps.FridgeTemp < ranges.FridgeMin)
            Console.WriteLine("Fridge temperature is TOO LOW!");
        else if (temps.FridgeTemp > ranges.FridgeMax)
            Console.WriteLine("Fridge temperature is TOO HIGH!");
        else
            Console.WriteLine("Fridge temperature is OK.");

        // Ambient
        if (temps.AmbientTemp < ranges.AmbientMin)
            Console.WriteLine("Ambient temperature is TOO LOW!");
        else if (temps.AmbientTemp > ranges.AmbientMax)
            Console.WriteLine("Ambient temperature is TOO HIGH!");
        else
            Console.WriteLine("Ambient temperature is OK.");
    }
}