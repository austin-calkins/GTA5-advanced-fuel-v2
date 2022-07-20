using System;

namespace Advanced_Fuel_Mod_v2
{
    internal class KeyBindings
    {
        private IniParser parser;

        public static int CUT_OFF_ENGINE;

        public static int FILL_CAR_WITH_JERRY_CAN;

        public static int RESET_TRIP_COMPUTER;

        public static int TOGGLE_SHOW_VEHICLE_STATS;

        private static string currentKeyBinding;

        static KeyBindings()
        {
            KeyBindings.CUT_OFF_ENGINE = 79;
            KeyBindings.FILL_CAR_WITH_JERRY_CAN = 76;
            KeyBindings.RESET_TRIP_COMPUTER = 110;
            KeyBindings.TOGGLE_SHOW_VEHICLE_STATS = 121;
        }

        public KeyBindings()
        {
        }

        public static void loadKeyBindings(string file)
        {
            try
            {
                IniParser iniParser = new IniParser(file);
                KeyBindings.currentKeyBinding = "CutOffEngine";
                KeyBindings.CUT_OFF_ENGINE = int.Parse(iniParser.GetSetting("KeyBindings", "CutOffEngine"));
                KeyBindings.currentKeyBinding = "FillCarWithJerryCan";
                KeyBindings.FILL_CAR_WITH_JERRY_CAN = int.Parse(iniParser.GetSetting("KeyBindings", "FillCarWithJerryCan"));
                KeyBindings.currentKeyBinding = "ResetTripComputer";
                KeyBindings.RESET_TRIP_COMPUTER = int.Parse(iniParser.GetSetting("KeyBindings", "ResetTripComputer"));
                KeyBindings.currentKeyBinding = "ToggleShowVehicleStats";
                KeyBindings.TOGGLE_SHOW_VEHICLE_STATS = int.Parse(iniParser.GetSetting("KeyBindings", "ToggleShowVehicleStats"));
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                throw new Exception(string.Concat(KeyBindings.currentKeyBinding, "\n", exception.ToString()));
            }
        }
    }
}