using System;

namespace Advanced_Fuel_Mod_v2
{
    public class Converter
    {
        public Converter()
        {
        }

        public static float convertLitresToGallons(float litres)
        {
            return (float)((double)litres * 3.785);
        }

        public static float convertLitresToPercentage(float litres, float maxLitres)
        {
            return (float)litres / maxLitres;
        }

        public static float convertPercentageToLitres(float percentage, int totalLitres)
        {
            return (float)totalLitres * percentage;
        }

        public static float convertToMiles(float kilometres)
        {
            return kilometres * 0.621f;
        }

        public static float convertToMPG(float litresPer100km)
        {
            float single = (float)((double)(100f / litresPer100km) * 0.621504039776259 * 3.785);
            return single;
        }
    }
}