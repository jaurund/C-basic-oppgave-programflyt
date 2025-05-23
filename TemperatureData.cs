public class TemperatureData
{
    public double FreezerTemp { get; }
    public double FridgeTemp { get; }
    public double AmbientTemp { get; }

    public TemperatureData(double freezer, double fridge, double ambient)
    {
        FreezerTemp = freezer;
        FridgeTemp = fridge;
        AmbientTemp = ambient;
    }
}