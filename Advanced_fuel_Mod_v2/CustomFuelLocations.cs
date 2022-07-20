using System;
using System.Collections.Generic;

namespace Advanced_Fuel_Mod_v2
{
    internal class CustomFuelLocations
    {
        public static List<FuelLocation> petrolStations;

        public static List<FuelLocation> planeLocations;

        public static List<FuelLocation> heliPads;

        public static List<FuelLocation> boatDocks;

        static CustomFuelLocations()
        {
            CustomFuelLocations.petrolStations = new List<FuelLocation>();
            CustomFuelLocations.planeLocations = new List<FuelLocation>();
            CustomFuelLocations.heliPads = new List<FuelLocation>();
            CustomFuelLocations.boatDocks = new List<FuelLocation>();
        }

        public CustomFuelLocations()
        {
        }

        public static void loadAllLocations(string fileLocation)
        {
            CustomFuelLocations.loadPetrolStations(fileLocation);
            CustomFuelLocations.loadPlaneLocations(fileLocation);
            CustomFuelLocations.loadHelipads(fileLocation);
            CustomFuelLocations.loadBoatDocks(fileLocation);
        }

        public static void loadBoatDocks(string fileLocation)
        {
            IniParser iniParser = new IniParser(fileLocation);
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    CustomFuelLocations.boatDocks.Add(new FuelLocation(iniParser.GetSetting("boatDocks", string.Concat("FuelLocation", i)), 15f, false));
                }
                catch (Exception exception)
                {
                }
            }
        }

        public static void loadHelipads(string fileLocation)
        {
            IniParser iniParser = new IniParser(fileLocation);
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    CustomFuelLocations.heliPads.Add(new FuelLocation(iniParser.GetSetting("Helipads", string.Concat("FuelLocation", i)), 10f, false));
                }
                catch (Exception exception)
                {
                }
            }
        }

        public static void loadPetrolStations(string fileLocation)
        {
            IniParser iniParser = new IniParser(fileLocation);
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    CustomFuelLocations.petrolStations.Add(new FuelLocation(iniParser.GetSetting("PetrolStations", string.Concat("FuelLocation", i)), 12f, false));
                }
                catch (Exception exception)
                {
                }
            }
        }

        public static void loadPlaneLocations(string fileLocation)
        {
            IniParser iniParser = new IniParser(fileLocation);
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    CustomFuelLocations.planeLocations.Add(new FuelLocation(iniParser.GetSetting("PlaneRefuelLocations", string.Concat("FuelLocation", i)), 30f, false));
                }
                catch (Exception exception)
                {
                }
            }
        }
    }
}