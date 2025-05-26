public class TemperatureRanges
{
    public double FreezerMin { get; }
    public double FreezerMax { get; }

    public double FridgeMin { get; }
    public double FridgeMax { get; }

    public double AmbientMin { get; }
    public double AmbientMax { get; }

    public TemperatureRanges(
        double freezerMin,
        double freezerMax,
        double fridgeMin,
        double fridgeMax,
        double ambientMin,
        double ambientMax
    )
    {
        FreezerMin = freezerMin;
        FreezerMax = freezerMax;
        FridgeMin = fridgeMin;
        FridgeMax = fridgeMax;
        AmbientMin = ambientMin;
        AmbientMax = ambientMax;
    }
}
