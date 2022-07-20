using System;

namespace Advanced_Fuel_Mod_v2
{
    internal class UserSettings
    {
        public static bool verticalFuelBar;

        public static bool useMetric;

        public static bool showStats;

        public static bool CanDisableFuelUsage;

        public static float statsX;

        public static float statsY;

        public static float FuelX;

        public static float FuelY;

        public static float FuelW;

        public static int BackgroundFuelBarColourR;

        public static int BackgroundFuelBarColourG;

        public static int BackgroundFuelBarColourB;

        public static int BackgroundFuelBarColourA;

        public static int FullFuelBarColourR;

        public static int FullFuelBarColourG;

        public static int FullFuelBarColourB;

        public static int FullFuelBarColourA;

        public static int HalfFuelBarColourR;

        public static int HalfFuelBarColourG;

        public static int HalfFuelBarColourB;

        public static int HalfFuelBarColourA;

        public static int QuaterFuelBarColourR;

        public static int QuaterFuelBarColourG;

        public static int QuaterFuelBarColourB;

        public static int QuaterFuelBarColourA;

        public static int notchColourR;

        public static int notchColourG;

        public static int notchColourB;

        public static int notchColourA;

        public static int startMin;

        public static int startMax;

        public static int absMin;

        public static int absMax;

        public static string petrolTerm;

        public static bool useMoreFuelWhenLeaking;

        static UserSettings()
        {
            UserSettings.verticalFuelBar = false;
            UserSettings.useMetric = true;
            UserSettings.showStats = false;
            UserSettings.CanDisableFuelUsage = false;
            UserSettings.statsX = 0.17f;
            UserSettings.statsY = 0.87f;
            UserSettings.FuelX = 0.073f;
            UserSettings.FuelY = 0.8f;
            UserSettings.FuelW = 0.13f;
            UserSettings.BackgroundFuelBarColourR = 255;
            UserSettings.BackgroundFuelBarColourG = 255;
            UserSettings.BackgroundFuelBarColourB = 255;
            UserSettings.BackgroundFuelBarColourA = 100;
            UserSettings.FullFuelBarColourR = 255;
            UserSettings.FullFuelBarColourG = 255;
            UserSettings.FullFuelBarColourB = 255;
            UserSettings.FullFuelBarColourA = 255;
            UserSettings.HalfFuelBarColourR = 255;
            UserSettings.HalfFuelBarColourG = 255;
            UserSettings.HalfFuelBarColourB = 255;
            UserSettings.HalfFuelBarColourA = 255;
            UserSettings.QuaterFuelBarColourR = 255;
            UserSettings.QuaterFuelBarColourG = 0;
            UserSettings.QuaterFuelBarColourB = 0;
            UserSettings.QuaterFuelBarColourA = 255;
            UserSettings.notchColourR = 0;
            UserSettings.notchColourG = 0;
            UserSettings.notchColourB = 0;
            UserSettings.notchColourA = 255;
            UserSettings.startMin = 110;
            UserSettings.startMax = 170;
            UserSettings.absMin = 70;
            UserSettings.absMax = 250;
            UserSettings.petrolTerm = "Petrol";
            UserSettings.useMoreFuelWhenLeaking = false;
        }

        public UserSettings()
        {
        }

        public static void loadSettings(string file)
        {
            IniParser iniParser = new IniParser(file);
            string str = "";
            try
            {
                try
                {
                    str = "VerticalFuelBar";
                    UserSettings.verticalFuelBar = iniParser.GetSetting("Settings", "VerticalFuelBar").Trim().ToUpper().Equals("TRUE");
                }
                catch (Exception exception)
                {
                }
                try
                {
                    str = "Units";
                    UserSettings.useMetric = iniParser.GetSetting("Settings", "Units").Trim().ToUpper().Contains("M");
                }
                catch (Exception exception1)
                {
                }
                try
                {
                    str = "ShowStatsByDefault";
                    UserSettings.showStats = iniParser.GetSetting("Settings", "ShowStatsByDefault").Trim().ToUpper().Equals("TRUE");
                }
                catch (Exception exception2)
                {
                }
                try
                {
                    str = "CanDisableFuelUsage";
                    UserSettings.CanDisableFuelUsage = iniParser.GetSetting("Settings", "CanDisableFuelUsage").Trim().ToUpper().Equals("TRUE");
                }
                catch (Exception exception3)
                {
                }
                try
                {
                    str = "StatsX";
                    UserSettings.statsX = float.Parse(iniParser.GetSetting("Positions", "StatsX"));
                }
                catch (Exception exception4)
                {
                }
                try
                {
                    str = "StatsY";
                    UserSettings.statsY = float.Parse(iniParser.GetSetting("Positions", "StatsY"));
                }
                catch (Exception exception5)
                {
                }
                try
                {
                    str = "FuelGaugeX";
                    UserSettings.FuelX = float.Parse(iniParser.GetSetting("Positions", "FuelGaugeX"));
                }
                catch (Exception exception6)
                {
                }
                try
                {
                    str = "FuelGaugeY";
                    UserSettings.FuelY = float.Parse(iniParser.GetSetting("Positions", "FuelGaugeY"));
                }
                catch (Exception exception7)
                {
                }
                try
                {
                    str = "FuelGuageLength";
                    UserSettings.FuelW = float.Parse(iniParser.GetSetting("Positions", "FuelGuageLength"));
                }
                catch (Exception exception8)
                {
                }
                try
                {
                    str = "BackgroundFuelBarColourR";
                    UserSettings.BackgroundFuelBarColourR = int.Parse(iniParser.GetSetting("FuelBarColours", "BackgroundFuelBarColourR"));
                }
                catch (Exception exception9)
                {
                }
                try
                {
                    str = "BackgroundFuelBarColourG";
                    UserSettings.BackgroundFuelBarColourG = int.Parse(iniParser.GetSetting("FuelBarColours", "BackgroundFuelBarColourG"));
                }
                catch (Exception exception10)
                {
                }
                try
                {
                    str = "BackgroundFuelBarColourB";
                    UserSettings.BackgroundFuelBarColourB = int.Parse(iniParser.GetSetting("FuelBarColours", "BackgroundFuelBarColourB"));
                }
                catch (Exception exception11)
                {
                }
                try
                {
                    str = "BackgroundFuelBarColourA";
                    UserSettings.BackgroundFuelBarColourA = int.Parse(iniParser.GetSetting("FuelBarColours", "BackgroundFuelBarColourA"));
                }
                catch (Exception exception12)
                {
                }
                try
                {
                    str = "FullFuelBarColourR";
                    UserSettings.FullFuelBarColourR = int.Parse(iniParser.GetSetting("FuelBarColours", "FullFuelBarColourR"));
                }
                catch (Exception exception13)
                {
                }
                try
                {
                    str = "FullFuelBarColourG";
                    UserSettings.FullFuelBarColourG = int.Parse(iniParser.GetSetting("FuelBarColours", "FullFuelBarColourG"));
                }
                catch (Exception exception14)
                {
                }
                try
                {
                    str = "FullFuelBarColourB";
                    UserSettings.FullFuelBarColourB = int.Parse(iniParser.GetSetting("FuelBarColours", "FullFuelBarColourB"));
                }
                catch (Exception exception15)
                {
                }
                try
                {
                    str = "FullFuelBarColourA";
                    UserSettings.FullFuelBarColourA = int.Parse(iniParser.GetSetting("FuelBarColours", "FullFuelBarColourA"));
                }
                catch (Exception exception16)
                {
                }
                try
                {
                    str = "HalfFuelBarColourR";
                    UserSettings.HalfFuelBarColourR = int.Parse(iniParser.GetSetting("FuelBarColours", "HalfFuelBarColourR"));
                }
                catch (Exception exception17)
                {
                }
                try
                {
                    str = "HalfFuelBarColourG";
                    UserSettings.HalfFuelBarColourG = int.Parse(iniParser.GetSetting("FuelBarColours", "HalfFuelBarColourG"));
                }
                catch (Exception exception18)
                {
                }
                try
                {
                    str = "HalfFuelBarColourB";
                    UserSettings.HalfFuelBarColourB = int.Parse(iniParser.GetSetting("FuelBarColours", "HalfFuelBarColourB"));
                }
                catch (Exception exception19)
                {
                }
                try
                {
                    str = "HalfFuelBarColourA";
                    UserSettings.HalfFuelBarColourA = int.Parse(iniParser.GetSetting("FuelBarColours", "HalfFuelBarColourA"));
                }
                catch (Exception exception20)
                {
                }
                try
                {
                    str = "QuaterFuelBarColourR";
                    UserSettings.QuaterFuelBarColourR = int.Parse(iniParser.GetSetting("FuelBarColours", "QuaterFuelBarColourR"));
                }
                catch (Exception exception21)
                {
                }
                try
                {
                    str = "QuaterFuelBarColourG";
                    UserSettings.QuaterFuelBarColourG = int.Parse(iniParser.GetSetting("FuelBarColours", "QuaterFuelBarColourG"));
                }
                catch (Exception exception22)
                {
                }
                try
                {
                    str = "QuaterFuelBarColourB";
                    UserSettings.QuaterFuelBarColourB = int.Parse(iniParser.GetSetting("FuelBarColours", "QuaterFuelBarColourB"));
                }
                catch (Exception exception23)
                {
                }
                try
                {
                    str = "QuaterFuelBarColourA";
                    UserSettings.QuaterFuelBarColourA = int.Parse(iniParser.GetSetting("FuelBarColours", "QuaterFuelBarColourA"));
                }
                catch (Exception exception24)
                {
                }
                try
                {
                    str = "NotchColourR";
                    UserSettings.notchColourR = int.Parse(iniParser.GetSetting("FuelBarColours", "NotchColourR"));
                }
                catch (Exception exception25)
                {
                }
                try
                {
                    str = "NotchColourG";
                    UserSettings.notchColourG = int.Parse(iniParser.GetSetting("FuelBarColours", "NotchColourG"));
                }
                catch (Exception exception26)
                {
                }
                try
                {
                    str = "NotchColourB";
                    UserSettings.notchColourB = int.Parse(iniParser.GetSetting("FuelBarColours", "NotchColourB"));
                }
                catch (Exception exception27)
                {
                }
                try
                {
                    str = "NotchColourA";
                    UserSettings.notchColourA = int.Parse(iniParser.GetSetting("FuelBarColours", "NotchColourA"));
                }
                catch (Exception exception28)
                {
                }
                try
                {
                    str = "StartingFuelMaxPrice";
                    UserSettings.startMin = int.Parse(iniParser.GetSetting("FuelPricing", "StartingFuelMaxPrice"));
                }
                catch (Exception exception29)
                {
                }
                try
                {
                    str = "StartingFuelMinPrice";
                    UserSettings.startMin = int.Parse(iniParser.GetSetting("FuelPricing", "StartingFuelMinPrice"));
                }
                catch (Exception exception30)
                {
                }
                try
                {
                    str = "AbsoluteFuelMaxPrice";
                    UserSettings.startMin = int.Parse(iniParser.GetSetting("FuelPricing", "AbsoluteFuelMaxPrice"));
                }
                catch (Exception exception31)
                {
                }
                try
                {
                    str = "AbsoluteFuelMinPrice";
                    UserSettings.startMin = int.Parse(iniParser.GetSetting("FuelPricing", "AbsoluteFuelMinPrice"));
                }
                catch (Exception exception32)
                {
                }
                try
                {
                    str = "TermForPetrol";
                    UserSettings.petrolTerm = iniParser.GetSetting("Terms", "Petrol");
                }
                catch (Exception exception33)
                {
                }
                try
                {
                    str = "UseMoreFuelWhenPetrolTankLeaking";
                    UserSettings.useMoreFuelWhenLeaking = iniParser.GetSetting("BetaFeatures", "UseMoreFuelWhenPetrolTankLeaking").Trim().ToUpper().Equals("TRUE");
                }
                catch (Exception exception34)
                {
                }
            }
            catch (Exception exception36)
            {
                Exception exception35 = exception36;
                LOG.write(string.Concat("Error retreiving setting: ", str, ". \n", exception35.ToString()));
            }
        }
    }
}