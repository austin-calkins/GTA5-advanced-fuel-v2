using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Fuel_Mod_v2
{
    public class GUI
    {
        public static bool displayStats;

        private int lastUpdate;

        private string vehicleStats;

        public static float instFuelCons;

        public static float avgFuelCons;

        public static float speed;

        public static float avgSpeed;

        public static float distance;

        public static float tankLevel;

        public static float tankSize;

        public static float range;

        public static float topSpeed;

        static GUI()
        {
            GUI.displayStats = true;
        }

        public GUI()
        {
        }

        public static void drawChargeMeter(FuelledVehicle v)
        {
            GUI.drawGuageHorizontal(v.chargeLevel, UserSettings.FuelW, 0.01f, UserSettings.FuelX, UserSettings.FuelY - 0.01f, new Colour(120, 255, 120, 255), new Colour(80, 180, 80, 255));
        }

        public static void drawFillTankText(int fuelPrice, int time, bool isStopped, string button, bool isElectric)
        {
            if (!UserSettings.useMetric)
            {
                fuelPrice = (int)Converter.convertLitresToGallons((float)fuelPrice);
            }
            float single = (float)fuelPrice / 100f;
            string str = single.ToString("0.00");
            string[] liquidUnits = new string[] { UserSettings.petrolTerm, " is $", str, "/", CONSTANTS.LiquidUnits };
            string str1 = string.Concat(liquidUnits);
            if (isElectric)
            {
                single = (float)fuelPrice / 100f;
                str1 = string.Concat("Electricity is $", single.ToString("0.00"), "/kwH");
            }
            if (isStopped)
            {
                string str2 = str1;
                liquidUnits = new string[] { str2, "\n", button, " to re", null };
                liquidUnits[4] = (isElectric ? "charge." : "fuel.");
                str1 = string.Concat(liquidUnits);
            }
            InputArgument[] inputArgumentArray = new InputArgument[] { 0 };
            Function.Call(7412968334783068634L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 1 };
            Function.Call(255613713711619320L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 0, 0.35 };
            Function.Call(560759698880214217L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 255, 255, 255, 255 };
            Function.Call(-4725643803099155390L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 0, 0, 0, 0, 255 };
            Function.Call(5070073224473199441L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 1, 0, 0, 0, 255 };
            Function.Call(4906112297440653222L, inputArgumentArray);
            Function.Call(2063750248883895902L, new InputArgument[0]);
            Function.Call(2671724955187806462L, new InputArgument[0]);
            inputArgumentArray = new InputArgument[] { "STRING" };
            Function.Call(2736978246810207435L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { str1 };
            Function.Call(7789129354908300458L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 0.015, 0.015 };
            Function.Call(-3674552073055540649L, inputArgumentArray);
        }

        public static void drawGuage(FuelledVehicle v)
        {
            if (!UserSettings.verticalFuelBar)
            {
                int fullFuelBarColourR = 255;
                int fullFuelBarColourG = 255;
                int fullFuelBarColourB = 255;
                int fullFuelBarColourA = 255;
                if ((double)v.fuelPercentage > 0.5)
                {
                    fullFuelBarColourR = UserSettings.FullFuelBarColourR;
                    fullFuelBarColourG = UserSettings.FullFuelBarColourG;
                    fullFuelBarColourB = UserSettings.FullFuelBarColourB;
                    fullFuelBarColourA = UserSettings.FullFuelBarColourA;
                }
                else if ((double)v.fuelPercentage <= 0.25)
                {
                    fullFuelBarColourR = UserSettings.QuaterFuelBarColourR;
                    fullFuelBarColourG = UserSettings.QuaterFuelBarColourG;
                    fullFuelBarColourB = UserSettings.QuaterFuelBarColourB;
                    fullFuelBarColourA = UserSettings.QuaterFuelBarColourA;
                }
                else
                {
                    fullFuelBarColourR = UserSettings.HalfFuelBarColourR;
                    fullFuelBarColourG = UserSettings.HalfFuelBarColourG;
                    fullFuelBarColourB = UserSettings.HalfFuelBarColourB;
                    fullFuelBarColourA = UserSettings.HalfFuelBarColourA;
                }
                GUI.drawGuageHorizontal(v.fuelPercentage, UserSettings.FuelW, 0.01f, UserSettings.FuelX, UserSettings.FuelY, new Colour(UserSettings.BackgroundFuelBarColourR, UserSettings.BackgroundFuelBarColourG, UserSettings.BackgroundFuelBarColourB, UserSettings.BackgroundFuelBarColourA), new Colour(fullFuelBarColourR, fullFuelBarColourG, fullFuelBarColourB, fullFuelBarColourA));
            }
            else
            {
                GUI.drawGuageVertical(v);
            }
        }

        private static void drawGuageHorizontal(float fuelPercentage, float width, float height, float xPos, float yPos, Colour backgroundColour, Colour foregroundColour)
        {
            float single = width * fuelPercentage;
            InputArgument[] notchX = new InputArgument[] { (float)xPos, (float)yPos, (float)width, (float)height, backgroundColour.r, backgroundColour.g, backgroundColour.b, backgroundColour.a };
            Function.Call(4206795403398567152L, notchX);
            notchX = new InputArgument[] { (float)(xPos - (width - single) / 2f), (float)yPos, (float)single, 0.01f, foregroundColour.r, foregroundColour.g, foregroundColour.b, foregroundColour.a };
            Function.Call(4206795403398567152L, notchX);
            float single1 = 0.001f;
            float single2 = 0.01f;
            float single3 = yPos + single2 / 2f;
            GUI.getNotchX(0f, single1, width, xPos);
            float single4 = 0.25f;
            GUI.getNotchX(single4, single1, width, xPos);
            float single5 = 0.5f;
            GUI.getNotchX(single5, single1, width, xPos);
            float single6 = 0.75f;
            GUI.getNotchX(single6, single1, width, xPos);
            GUI.getNotchX(1f, single1, width, xPos);
            int num = UserSettings.notchColourR;
            int num1 = UserSettings.notchColourG;
            int num2 = UserSettings.notchColourB;
            int num3 = UserSettings.notchColourA;
            notchX = new InputArgument[] { (float)GUI.getNotchX(single4, single1, width, xPos), (float)yPos, (float)single1, (float)single2, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, notchX);
            notchX = new InputArgument[] { (float)GUI.getNotchX(single5, single1, width, xPos), (float)yPos, (float)single1, (float)single2, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, notchX);
            notchX = new InputArgument[] { (float)GUI.getNotchX(single6, single1, width, xPos), (float)yPos, (float)single1, (float)single2, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, notchX);
        }

        private static void drawGuageVertical(FuelledVehicle v)
        {
            int fullFuelBarColourR;
            int fullFuelBarColourG;
            int fullFuelBarColourB;
            int fullFuelBarColourA;
            float fuelX = UserSettings.FuelX + 0.08f;
            float fuelY = UserSettings.FuelY + 0.12f;
            if ((double)v.fuelPercentage > 0.5)
            {
                fullFuelBarColourR = UserSettings.FullFuelBarColourR;
                fullFuelBarColourG = UserSettings.FullFuelBarColourG;
                fullFuelBarColourB = UserSettings.FullFuelBarColourB;
                fullFuelBarColourA = UserSettings.FullFuelBarColourA;
            }
            else if ((double)v.fuelPercentage <= 0.25)
            {
                fullFuelBarColourR = UserSettings.QuaterFuelBarColourR;
                fullFuelBarColourG = UserSettings.QuaterFuelBarColourG;
                fullFuelBarColourB = UserSettings.QuaterFuelBarColourB;
                fullFuelBarColourA = UserSettings.QuaterFuelBarColourA;
            }
            else
            {
                fullFuelBarColourR = UserSettings.HalfFuelBarColourR;
                fullFuelBarColourG = UserSettings.HalfFuelBarColourG;
                fullFuelBarColourB = UserSettings.HalfFuelBarColourB;
                fullFuelBarColourA = UserSettings.HalfFuelBarColourA;
            }
            InputArgument[] fuelW = new InputArgument[] { (float)fuelX, (float)fuelY, 0.01f, (float)UserSettings.FuelW, UserSettings.BackgroundFuelBarColourR, UserSettings.BackgroundFuelBarColourG, UserSettings.BackgroundFuelBarColourB, UserSettings.BackgroundFuelBarColourA };
            Function.Call(4206795403398567152L, fuelW);
            float single = UserSettings.FuelW * v.fuelPercentage;
            float fuelW1 = UserSettings.FuelW - single;
            fuelW = new InputArgument[] { (float)fuelX, (float)(fuelY + fuelW1 / 2f), 0.01f, (float)(v.fuelPercentage * UserSettings.FuelW), fullFuelBarColourR, fullFuelBarColourG, fullFuelBarColourB, fullFuelBarColourA };
            Function.Call(4206795403398567152L, fuelW);
            int num = UserSettings.notchColourR;
            int num1 = UserSettings.notchColourG;
            int num2 = UserSettings.notchColourB;
            int num3 = UserSettings.notchColourA;
            fuelW = new InputArgument[] { (float)fuelX, (float)GUI.getNotchY(0.25f, 0.001f, UserSettings.FuelW, fuelY), 0.01f, 0.001f, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, fuelW);
            fuelW = new InputArgument[] { (float)fuelX, (float)GUI.getNotchY(0.5f, 0.001f, UserSettings.FuelW, fuelY), 0.01f, 0.001f, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, fuelW);
            fuelW = new InputArgument[] { (float)fuelX, (float)GUI.getNotchY(0.75f, 0.001f, UserSettings.FuelW, fuelY), 0.01f, 0.001f, num, num1, num2, num3 };
            Function.Call(4206795403398567152L, fuelW);
        }

        public static void drawText(string text, float x, float y, float textSize)
        {
            InputArgument[] inputArgumentArray = new InputArgument[] { 0 };
            Function.Call(7412968334783068634L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 1 };
            Function.Call(255613713711619320L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 0, (float)textSize };
            Function.Call(560759698880214217L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 255, 255, 255, 255 };
            Function.Call(-4725643803099155390L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 0, 0, 0, 0, 255 };
            Function.Call(5070073224473199441L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { 1, 0, 0, 0, 255 };
            Function.Call(4906112297440653222L, inputArgumentArray);
            Function.Call(2063750248883895902L, new InputArgument[0]);
            Function.Call(2671724955187806462L, new InputArgument[0]);
            inputArgumentArray = new InputArgument[] { "STRING" };
            Function.Call(2736978246810207435L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { text };
            Function.Call(7789129354908300458L, inputArgumentArray);
            inputArgumentArray = new InputArgument[] { (float)x, (float)y };
            Function.Call(-3674552073055540649L, inputArgumentArray);
        }

        public static void drawText(string text, float x, float y)
        {
            GUI.drawText(text, x, y, 0.35f);
        }

        public static void drawVehicleStats(FuelledVehicle v, int time, bool useImperial)
        {
            if ((!GUI.displayStats ? false : !Function.Call<bool>(-3187737643600379106L, new InputArgument[0])))
            {
                GUI.instFuelCons = v.instFC;
                if (useImperial)
                {
                    GUI.instFuelCons = Converter.convertToMPG(GUI.instFuelCons);
                }
                GUI.avgFuelCons = v.avgFuelConsumption.Average();
                if (useImperial)
                {
                    GUI.instFuelCons = Converter.convertToMPG(GUI.avgFuelCons);
                }
                GUI.speed = (float)((double)v.vehicle.get_Speed() * 3.6);
                if (useImperial)
                {
                    GUI.speed = Converter.convertToMiles(GUI.speed);
                }
                GUI.avgSpeed = v.avgSpeed.Average();
                if (useImperial)
                {
                    GUI.avgSpeed = Converter.convertToMiles(GUI.avgSpeed);
                }
                GUI.distance = v.distance;
                if (useImperial)
                {
                    GUI.distance = Converter.convertToMiles(GUI.distance);
                }
                GUI.tankLevel = v.tankSize * v.fuelPercentage;
                if (useImperial)
                {
                    GUI.tankLevel = Converter.convertLitresToGallons(GUI.tankLevel);
                }
                GUI.tankSize = v.tankSize;
                if (useImperial)
                {
                    GUI.tankSize = Converter.convertLitresToGallons(GUI.tankSize);
                }
                GUI.range = v.tankSize * v.fuelPercentage / v.avgFuelConsumption.Average() * 100f;
                if (v.isElectric)
                {
                    GUI.range = v.fuelUsedSinceLastRefuel / v.distanceSinceLastRefuel * (v.tankSize * v.chargeLevel);
                }
                if (useImperial)
                {
                    GUI.range = Converter.convertToMiles(GUI.range);
                }
                GUI.topSpeed = v.topSpeed;
                if (useImperial)
                {
                    GUI.topSpeed = Converter.convertToMiles(GUI.topSpeed);
                }
                object[] str = new object[] { (v.vehicle.get_Acceleration() >= 0f ? true : !v.vehicle.IsInBurnout()), " - ", v.isElectric, ", ", KeyBindingsIntl.ENABLE_DISABLE_FUEL_USAGE, " - ", UserSettings.CanDisableFuelUsage.ToString(), " - ", v.vehicle.get_DisplayName(), " - ", null };
                Vector3 position = v.vehicle.get_Position();
                str[10] = position.ToString();
                GUI.drawText(string.Concat(str), 0.1f, 0.1f);
                foreach (TextElement textElement in CONSTANTS.textElements)
                {
                    try
                    {
                        GUI.drawText(GUI.parseText(textElement.text, v), textElement.xPos, textElement.yPos, textElement.fontSize);
                    }
                    catch (Exception exception)
                    {
                    }
                }
            }
        }

        public static float getNotchX(float percent, float notchWidth, float barWidth, float barX)
        {
            barX = barX - barWidth / 2f;
            return barX + percent * barWidth;
        }

        public static float getNotchY(float percent, float notchHeight, float barWidth, float barY)
        {
            barY = barY - barWidth / 2f;
            return barY + percent * barWidth;
        }

        public static string parseText(string text, FuelledVehicle v)
        {
            string str;
            float single;
            try
            {
                if (!(text == null ? false : !(text == "")))
                {
                    str = "text is null";
                }
                else if (null != v)
                {
                    string str1 = text;
                    string str2 = "<INST_FUEL_CONSUMPTION>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.instFuelCons.ToString("0.00"));
                    }
                    str2 = "<AVERAGE_FUEL_CONSUMPTION>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.avgFuelCons.ToString("0.00"));
                    }
                    str2 = "<SPEED>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.speed.ToString("0.00"));
                    }
                    str2 = "<AVERAGE_SPEED>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.avgSpeed.ToString("0.00"));
                    }
                    str2 = "<DISTANCE_DRIVEN>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.distance.ToString("0.00"));
                    }
                    str2 = "<FUEL_PERCENTAGE>";
                    if (str1.Contains(str2))
                    {
                        single = v.fuelPercentage * 100f;
                        str1 = str1.Replace(str2, single.ToString("0.00"));
                    }
                    str2 = "<FUEL_REMAINING>";
                    if (str1.Contains(str2))
                    {
                        single = v.tankSize * v.fuelPercentage;
                        str1 = str1.Replace(str2, single.ToString("0.00"));
                    }
                    str2 = "<TANK_SIZE>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, v.tankSize.ToString("0.00"));
                    }
                    str2 = "<TOP_SPEED>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.topSpeed.ToString("0.00"));
                    }
                    str2 = "<RANGE>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, GUI.range.ToString("0.00"));
                    }
                    str2 = "<FUEL_CONSUMPTION_UNITS>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, (v.isElectric ? "kWh" : CONSTANTS.fuelConsumptionUnits));
                    }
                    str2 = "<SPEED_UNITS>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, CONSTANTS.unitsPerHour);
                    }
                    str2 = "<DISTANCE_UNITS>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, CONSTANTS.distanceUnits);
                    }
                    str2 = "<LIQUID_UNITS>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, CONSTANTS.LiquidUnits);
                    }
                    str2 = "<FUEL_UNITS>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, (v.isElectric ? "kWh" : CONSTANTS.LiquidUnits));
                    }
                    str2 = "<FUEL>";
                    if (str1.Contains(str2))
                    {
                        str1 = str1.Replace(str2, (v.isElectric ? "Electricity" : "Fuel"));
                    }
                    str = str1;
                }
                else
                {
                    str = "vehicle is null";
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                object[] objArray = new object[] { exception.ToString(), "\n", v.tankSize, "\n", text };
                LOG.write(string.Concat(objArray));
                str = "[error displaying message]";
                return str;
            }
            return str;
        }
    }
}