// Checks temperatures from file, and defines them against set ranges in tempRanges.txt

public class TemperatureChecker
{
    public void CheckTemperatures(TemperatureData temps, TemperatureRanges ranges)
    {
        // Freezer
        if (temps.FreezerTemp < ranges.FreezerMin)
            Console.WriteLine("Freezer temperature is TOO LOW! Meats may reduce in quality.");
        else if (temps.FreezerTemp > ranges.FreezerMax)
            Console.WriteLine("Freezer temperature is TOO HIGH! Take action to avoid spoilage.");
        else
            Console.WriteLine("Freezer temperature is OK.");

        // Fridge
        if (temps.FridgeTemp < ranges.FridgeMin)
            Console.WriteLine("Fridge temperature is TOO LOW! Check for proper cooling.");
        else if (temps.FridgeTemp > ranges.FridgeMax)
            Console.WriteLine("Fridge temperature is TOO HIGH! Take action to avoid freezing.");
        else
            Console.WriteLine("Fridge temperature is OK.");

        // Ambient
        if (temps.AmbientTemp < ranges.AmbientMin)
            Console.WriteLine("Ambient temperature is TOO LOW! Check heating system.");
        else if (temps.AmbientTemp > ranges.AmbientMax)
            Console.WriteLine(
                "Ambient temperature is TOO HIGH! Fridges and freezers might fail. Check ventilation and/or AC system."
            );
        else
            Console.WriteLine("Ambient temperature is OK.");
    }
}
