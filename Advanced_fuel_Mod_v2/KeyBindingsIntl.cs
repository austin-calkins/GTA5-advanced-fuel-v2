using System;

namespace Advanced_Fuel_Mod_v2
{
    internal class KeyBindingsIntl
    {
        private static IniParser parser;

        public static string CUT_OFF_ENGINE;

        public static string FILL_CAR_WITH_JERRY_CAN;

        public static string RESET_TRIP_COMPUTER;

        public static string TOGGLE_SHOW_VEHICLE_STATS;

        public static string RELOAD_SETTINGS;

        public static string ENABLE_DISABLE_FUEL_USAGE;

        static KeyBindingsIntl()
        {
            KeyBindingsIntl.CUT_OFF_ENGINE = "O";
            KeyBindingsIntl.FILL_CAR_WITH_JERRY_CAN = "L";
            KeyBindingsIntl.RESET_TRIP_COMPUTER = "F9";
            KeyBindingsIntl.TOGGLE_SHOW_VEHICLE_STATS = "F10";
            KeyBindingsIntl.RELOAD_SETTINGS = "F11";
            KeyBindingsIntl.ENABLE_DISABLE_FUEL_USAGE = "";
        }

        public KeyBindingsIntl()
        {
        }

        public static bool getCutOffEngine(string s)
        {
            return s.Equals(KeyBindingsIntl.CUT_OFF_ENGINE);
        }

        public static bool getEnableDisableFuelUsage(string s)
        {
            return s.Equals(KeyBindingsIntl.ENABLE_DISABLE_FUEL_USAGE);
        }

        public static bool getFillCarWithJerryCan(string s)
        {
            return s.Equals(KeyBindingsIntl.FILL_CAR_WITH_JERRY_CAN);
        }

        public static bool getReloadSettings(string s)
        {
            return s.Equals(KeyBindingsIntl.RELOAD_SETTINGS);
        }

        public static bool getResetTripComputer(string s)
        {
            return s.Equals(KeyBindingsIntl.RESET_TRIP_COMPUTER);
        }

        public static bool getToggleShowVehicleStats(string s)
        {
            return s.Equals(KeyBindingsIntl.TOGGLE_SHOW_VEHICLE_STATS);
        }

        public static void loadSettings(string file)
        {
            KeyBindingsIntl.parser = new IniParser(file);
            try
            {
                KeyBindingsIntl.CUT_OFF_ENGINE = KeyBindingsIntl.parser.GetSetting("KeyBindings", "CutOffEngine");
                KeyBindingsIntl.FILL_CAR_WITH_JERRY_CAN = KeyBindingsIntl.parser.GetSetting("KeyBindings", "FillCarWithJerryCan");
                KeyBindingsIntl.RESET_TRIP_COMPUTER = KeyBindingsIntl.parser.GetSetting("KeyBindings", "ResetTripComputer");
                KeyBindingsIntl.TOGGLE_SHOW_VEHICLE_STATS = KeyBindingsIntl.parser.GetSetting("KeyBindings", "ToggleShowVehicleStats");
                KeyBindingsIntl.RELOAD_SETTINGS = KeyBindingsIntl.parser.GetSetting("KeyBindings", "ReloadSettings");
                KeyBindingsIntl.ENABLE_DISABLE_FUEL_USAGE = KeyBindingsIntl.parser.GetSetting("KeyBindings", "EnableDisableFuelUsage");
            }
            catch (Exception exception)
            {
                LOG.write(string.Concat("Error getting key Bindings\n", exception.ToString()));
            }
        }
    }
}