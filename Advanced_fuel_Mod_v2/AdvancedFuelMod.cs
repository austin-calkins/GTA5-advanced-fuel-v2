using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Advanced_Fuel_Mod_v2
{
    public class AdvancedFuelMod : Script
    {
        private int manualRefuelTime;

        private Ped pedCurrentPlayer;

        private Player playerCurrentPlayer;

        private int fuelPrice = 0;

        private int electricityPrice = 0;

        private int updateTime = 10;

        private Random rng = new Random();

        private bool init = false;

        private int lastFuelUpdate = 0;

        private int lastElectricityUpdate = 0;

        private FuelledVehicle currentVehicle;

        private bool inVehicle;

        private List<FuelledVehicle> vehicles = new List<FuelledVehicle>();

        private List<Blip> blips = new List<Blip>();

        private bool manualRefuel = false;

        private bool honkingHorn = false;

        private bool oldHonkingHorn = false;

        public static string newVersion;

        static AdvancedFuelMod()
        {
            AdvancedFuelMod.newVersion = "Loading...";
        }

        public AdvancedFuelMod()
        {
            this.loadSettings();
            this.pedCurrentPlayer = Game.get_Player().get_Character();
            this.playerCurrentPlayer = Function.Call<Player>(5730343094349521110L, new InputArgument[0]);
            base.add_Tick(new EventHandler(this.OnTick));
            base.add_KeyDown(new KeyEventHandler(this.OnKeyDown));
            base.add_KeyUp(new KeyEventHandler(this.OnKeyUp));
            base.set_Interval(this.updateTime);
            CONSTANTS.loadFuelTanks();
            CONSTANTS.loadElectricFuelPoints();
            CONSTANTS.loadElectricVehicles();
        }

        public void initialise()
        {
            FuelLocation petrolStation = null;
            Blip blip;
            InputArgument[] x;
            this.fuelPrice = this.rng.Next(UserSettings.startMin, UserSettings.startMax);
            GUI.displayStats = UserSettings.showStats;
            this.init = true;
            foreach (FuelLocation petrolStation in CustomFuelLocations.petrolStations)
            {
                if (petrolStation.showBlip)
                {
                    x = new InputArgument[] { (float)petrolStation.x, (float)petrolStation.y, (float)petrolStation.z };
                    blip = Function.Call<Blip>(6486199071725192374L, x);
                    x = new InputArgument[] { blip, 361 };
                    Function.Call(-2345436420171534929L, x);
                    x = new InputArgument[] { blip, 0.8 };
                    Function.Call(-3204517746504129961L, x);
                    x = new InputArgument[] { blip, true };
                    Function.Call(-4716424403542181006L, x);
                    this.blips.Add(blip);
                }
            }
            foreach (FuelLocation planeLocation in CustomFuelLocations.planeLocations)
            {
                if (planeLocation.showBlip)
                {
                    x = new InputArgument[] { (float)planeLocation.x, (float)planeLocation.y, (float)planeLocation.z };
                    blip = Function.Call<Blip>(6486199071725192374L, x);
                    x = new InputArgument[] { blip, 361 };
                    Function.Call(-2345436420171534929L, x);
                    x = new InputArgument[] { blip, 0.8 };
                    Function.Call(-3204517746504129961L, x);
                    x = new InputArgument[] { blip, true };
                    Function.Call(-4716424403542181006L, x);
                    this.blips.Add(blip);
                }
            }
            foreach (FuelLocation heliPad in CustomFuelLocations.heliPads)
            {
                if (heliPad.showBlip)
                {
                    x = new InputArgument[] { (float)heliPad.x, (float)heliPad.y, (float)heliPad.z };
                    blip = Function.Call<Blip>(6486199071725192374L, x);
                    x = new InputArgument[] { blip, 361 };
                    Function.Call(-2345436420171534929L, x);
                    x = new InputArgument[] { blip, 0.8 };
                    Function.Call(-3204517746504129961L, x);
                    x = new InputArgument[] { blip, true };
                    Function.Call(-4716424403542181006L, x);
                    this.blips.Add(blip);
                }
            }
            foreach (FuelLocation boatDock in CustomFuelLocations.boatDocks)
            {
                if (boatDock.showBlip)
                {
                    x = new InputArgument[] { (float)boatDock.x, (float)boatDock.y, (float)boatDock.z };
                    blip = Function.Call<Blip>(6486199071725192374L, x);
                    x = new InputArgument[] { blip, 361 };
                    Function.Call(-2345436420171534929L, x);
                    x = new InputArgument[] { blip, 0.8 };
                    Function.Call(-3204517746504129961L, x);
                    x = new InputArgument[] { blip, true };
                    Function.Call(-4716424403542181006L, x);
                    this.blips.Add(blip);
                }
            }
            foreach (Vector3 electricFuelPoint in CONSTANTS.electricFuelPoints)
            {
                x = new InputArgument[] { (float)electricFuelPoint.X, (float)electricFuelPoint.Y, (float)electricFuelPoint.Z };
                blip = Function.Call<Blip>(6486199071725192374L, x);
                x = new InputArgument[] { blip, 354 };
                Function.Call(-2345436420171534929L, x);
                x = new InputArgument[] { blip, 0.9 };
                Function.Call(-3204517746504129961L, x);
                x = new InputArgument[] { blip, true };
                Function.Call(-4716424403542181006L, x);
                this.blips.Add(blip);
            }
        }

        private bool isVehicleElectric(Vehicle vehicle)
        {
            bool flag;
            foreach (string electricVehicle in CONSTANTS.electricVehicles)
            {
                if (vehicle.get_DisplayName().ToLower().Equals(electricVehicle.ToLower()))
                {
                    flag = true;
                    return flag;
                }
            }
            flag = false;
            return flag;
        }

        private bool isVehicleHybrid(Vehicle vehicle)
        {
            bool flag;
            foreach (string hybridVehicle in CONSTANTS.hybridVehicles)
            {
                if (vehicle.get_DisplayName().ToLower().Equals(hybridVehicle.ToLower()))
                {
                    flag = true;
                    return flag;
                }
            }
            flag = false;
            return flag;
        }

        public void loadSettings()
        {
            string str = "Scripts/Advanced_Fuel_Mod_Settings.ini";
            UserSettings.loadSettings(str);
            KeyBindingsIntl.loadSettings(str);
            CustomFuelLocations.loadAllLocations(str);
            CONSTANTS.loadTextElements(str);
            if (!UserSettings.useMetric)
            {
                CONSTANTS.distanceUnits = "miles";
                CONSTANTS.fuelConsumptionUnits = "mpg";
                CONSTANTS.unitsPerHour = "mph";
                CONSTANTS.LiquidUnits = "gallon";
            }
        }

        private void onDispose(object sender, EventArgs e)
        {
            foreach (Blip blip in this.blips)
            {
                blip.Remove();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (KeyBindingsIntl.getFillCarWithJerryCan(e.KeyCode.ToString()))
            {
                this.manualRefuel = true;
                this.manualRefuelTime = Game.get_GameTime();
            }
            if (KeyBindingsIntl.getCutOffEngine(e.KeyCode.ToString()))
            {
                this.currentVehicle.cutEngine = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (KeyBindingsIntl.getFillCarWithJerryCan(e.KeyCode.ToString()))
                {
                    this.manualRefuel = false;
                }
                if ((!KeyBindingsIntl.getResetTripComputer(e.KeyCode.ToString()) ? false : this.pedCurrentPlayer.IsInVehicle()))
                {
                    this.currentVehicle.resetTripComputer();
                }
                if (KeyBindingsIntl.getToggleShowVehicleStats(e.KeyCode.ToString()))
                {
                    GUI.displayStats = !GUI.displayStats;
                }
                if (KeyBindingsIntl.getReloadSettings(e.KeyCode.ToString()))
                {
                    this.loadSettings();
                }
                if (KeyBindingsIntl.getEnableDisableFuelUsage(e.KeyCode.ToString()))
                {
                    if ((!this.pedCurrentPlayer.IsInVehicle() ? false : UserSettings.CanDisableFuelUsage))
                    {
                        this.currentVehicle.vehicle.set_LightsOn(!this.currentVehicle.vehicle.get_LightsOn());
                        this.currentVehicle.toggleEnableFuelUsage();
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                LOG.write(string.Concat("Error on keyUp Event: ", e.KeyCode.ToString(), "\n", exception.ToString()));
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            InputArgument[] hash;
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            if (!this.init)
            {
                this.initialise();
            }
            int gameTime = Game.get_GameTime();
            this.pedCurrentPlayer = Game.get_Player().get_Character();
            this.playerCurrentPlayer = Function.Call<Player>(5730343094349521110L, new InputArgument[0]);
            if ((float)(gameTime - this.lastFuelUpdate) > 1000f * (60f * 10f))
            {
                this.fuelPrice = this.rng.Next(this.fuelPrice - 10, this.fuelPrice + 11);
                while (true)
                {
                    if ((this.fuelPrice < UserSettings.absMin ? false : this.fuelPrice <= UserSettings.absMax))
                    {
                        break;
                    }
                    this.fuelPrice = this.rng.Next(this.fuelPrice - 10, this.fuelPrice + 11);
                }
                this.lastFuelUpdate = gameTime;
            }
            if ((float)(gameTime - this.lastElectricityUpdate) > 1000f * (60f * 0.016f))
            {
                this.electricityPrice = 30;
                switch (Function.Call<int>(2675767815307398015L, new InputArgument[0]))
                {
                    case 0:
                    case 1:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.2f);
                            break;
                        }
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.1f);
                            break;
                        }
                    case 6:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.2f);
                            break;
                        }
                    case 7:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.5f);
                            break;
                        }
                    case 8:
                    case 9:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.6f);
                            break;
                        }
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.5f);
                            break;
                        }
                    case 16:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.6f);
                            break;
                        }
                    case 17:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.7f);
                            break;
                        }
                    case 18:
                    case 19:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.8f);
                            break;
                        }
                    case 20:
                    case 21:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.5f);
                            break;
                        }
                    case 22:
                    case 23:
                        {
                            this.electricityPrice = (int)((float)this.electricityPrice * 0.3f);
                            break;
                        }
                }
                this.lastElectricityUpdate = gameTime;
            }
            try
            {
                this.oldHonkingHorn = this.honkingHorn;
                hash = new InputArgument[] { this.currentVehicle.vehicle };
                this.honkingHorn = Function.Call<bool>(-7103306830048370399L, hash);
                if ((!this.currentVehicle.isRefuelling || this.oldHonkingHorn ? false : this.honkingHorn))
                {
                    this.currentVehicle.stopRefuelling((float)(this.fuelPrice / 100), this.playerCurrentPlayer);
                }
            }
            catch (Exception exception)
            {
            }
            if ((!this.pedCurrentPlayer.IsInVehicle() ? false : null != this.currentVehicle))
            {
                List<FuelLocation> fuelLocations = new List<FuelLocation>();
                string str = "Honk horn";
                if (!this.currentVehicle.isElectric)
                {
                    fuelLocations = CustomFuelLocations.petrolStations;
                    hash = new InputArgument[] { this.pedCurrentPlayer };
                    if (Function.Call<bool>(6917332199840217984L, hash))
                    {
                        fuelLocations = CustomFuelLocations.planeLocations;
                        str = string.Concat("Press ", KeyBindingsIntl.FILL_CAR_WITH_JERRY_CAN.ToString());
                    }
                    hash = new InputArgument[1];
                    Model model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                    hash[0] = model.get_Hash();
                    if (Function.Call<bool>(5019570168338364899L, hash))
                    {
                        fuelLocations = CustomFuelLocations.boatDocks;
                    }
                    hash = new InputArgument[1];
                    model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                    hash[0] = model.get_Hash();
                    if ((Function.Call<bool>(-2529840708346473238L, hash) ? true : this.pedCurrentPlayer.get_CurrentVehicle().get_DisplayName().ToUpper().Equals("BLIMP")))
                    {
                        fuelLocations = CustomFuelLocations.heliPads;
                        str = string.Concat("Press ", KeyBindingsIntl.FILL_CAR_WITH_JERRY_CAN.ToString());
                    }
                }
                else
                {
                    foreach (Vector3 electricFuelPoint in CONSTANTS.electricFuelPoints)
                    {
                        fuelLocations.Add(new FuelLocation(electricFuelPoint, true, true, 2f));
                    }
                }
                this.showPetrolStationNotification(fuelLocations, str);
            }
            if (!this.inVehicle)
            {
                hash = new InputArgument[] { this.pedCurrentPlayer, false };
                if (!Function.Call<bool>(-7387383988179580405L, hash))
                {
                    goto Label1;
                }
                flag = !this.vehicleUsesFuel();
                goto Label0;
            }
        Label1:
            flag = true;
        Label0:
            if (flag)
            {
                if (!this.inVehicle)
                {
                    flag1 = true;
                }
                else
                {
                    hash = new InputArgument[] { this.pedCurrentPlayer, false };
                    flag1 = Function.Call<bool>(-7387383988179580405L, hash);
                }
                if (!flag1)
                {
                    this.inVehicle = false;
                }
            }
            else
            {
                this.inVehicle = true;
                bool flag4 = false;
                foreach (FuelledVehicle vehicle in this.vehicles)
                {
                    if (this.pedCurrentPlayer.get_CurrentVehicle().get_Handle() == vehicle.handle)
                    {
                        flag4 = true;
                        this.currentVehicle = vehicle;
                    }
                }
                if (!flag4)
                {
                    this.currentVehicle = new FuelledVehicle(this.pedCurrentPlayer.get_CurrentVehicle());
                    this.vehicles.Insert(0, this.currentVehicle);
                    if (this.vehicles.Count > 10)
                    {
                        this.vehicles.RemoveRange(10, this.vehicles.Count - 10);
                    }
                }
            }
            if (this.inVehicle)
            {
                if (this.playerCurrentPlayer.get_CanControlCharacter())
                {
                    float single = (float)this.fuelPrice / 100f;
                    if (this.currentVehicle.isElectric)
                    {
                        single = (float)this.electricityPrice / 100f;
                    }
                    this.currentVehicle.update(single, this.playerCurrentPlayer, !UserSettings.useMetric, this.pedCurrentPlayer);
                    GUI.drawVehicleStats(this.currentVehicle, gameTime, !UserSettings.useMetric);
                    if (!this.currentVehicle.isElectric)
                    {
                        GUI.drawGuage(this.currentVehicle);
                    }
                    if ((this.currentVehicle.isElectric ? true : this.currentVehicle.isHyrbid))
                    {
                        GUI.drawChargeMeter(this.currentVehicle);
                    }
                }
            }
            if (this.currentVehicle != null)
            {
                if (!this.inVehicle)
                {
                    hash = new InputArgument[] { (float)this.pedCurrentPlayer.get_Position().X, (float)this.pedCurrentPlayer.get_Position().Y, (float)this.pedCurrentPlayer.get_Position().Z, (float)this.currentVehicle.vehicle.get_Position().X, (float)this.currentVehicle.vehicle.get_Position().Y, (float)this.currentVehicle.vehicle.get_Position().Z };
                    if (Function.Call<float>(-1029247852194248366L, hash) >= 2f || this.pedCurrentPlayer.get_Weapons().get_Current().get_Ammo() <= 0 || this.pedCurrentPlayer.get_Weapons().get_Current().get_Hash() != 883325847)
                    {
                        goto Label3;
                    }
                    flag2 = this.currentVehicle.isElectric;
                    goto Label2;
                }
            Label3:
                flag2 = true;
            Label2:
                if (!flag2)
                {
                    GUI.drawText("Press L to refuel from your Jerry Can.", 0.015f, 0.015f, 0.35f);
                    if (this.manualRefuel)
                    {
                        if (this.currentVehicle.fuelPercentage < 1f)
                        {
                            this.currentVehicle.fuelPercentage += Converter.convertLitresToPercentage(CONSTANTS.flowRateCar / 2f, this.currentVehicle.tankSize);
                            int ammo = this.pedCurrentPlayer.get_Weapons().get_Current().get_Ammo();
                            this.pedCurrentPlayer.get_Weapons().get_Current().set_Ammo(ammo - 1);
                            Game.get_Player().get_Character().get_Task().LookAt(this.currentVehicle.vehicle);
                            Animation.play("amb@prop_human_atm@male@exit", "exit", 4, this.currentVehicle.vehicle);
                        }
                        this.currentVehicle.update((float)this.fuelPrice / 100f, this.playerCurrentPlayer, !UserSettings.useMetric, this.pedCurrentPlayer);
                    }
                    GUI.drawGuage(this.currentVehicle);
                }
                if (!this.currentVehicle.cutEngine)
                {
                    flag3 = true;
                }
                else
                {
                    hash = new InputArgument[] { 2, 11 };
                    if (Function.Call<bool>(-891119206476391862L, hash))
                    {
                        flag3 = false;
                    }
                    else
                    {
                        hash = new InputArgument[] { 2, 71 };
                        flag3 = !Function.Call<bool>(-891119206476391862L, hash);
                    }
                }
                if (!flag3)
                {
                    this.currentVehicle.cutEngine = false;
                }
            }
        }

        private void showPetrolStationNotification(List<FuelLocation> fuelLocations, string button)
        {
            foreach (FuelLocation fuelLocation in fuelLocations)
            {
                InputArgument[] x = new InputArgument[] { (float)this.pedCurrentPlayer.get_Position().X, (float)this.pedCurrentPlayer.get_Position().Y, (float)this.pedCurrentPlayer.get_Position().Z, (float)fuelLocation.x, (float)fuelLocation.y, (float)fuelLocation.z };
                if (Function.Call<float>(-1029247852194248366L, x) < fuelLocation.range)
                {
                    int num = this.fuelPrice;
                    if (fuelLocation.isElectric)
                    {
                        num = this.electricityPrice;
                    }
                    GUI.drawFillTankText(num, this.updateTime, this.pedCurrentPlayer.get_CurrentVehicle().get_Speed() < 1f, button, fuelLocation.isElectric);
                    x = new InputArgument[] { this.currentVehicle.vehicle };
                    if (!(!Function.Call<bool>(-7103306830048370399L, x) ? true : this.pedCurrentPlayer.get_CurrentVehicle().get_Speed() >= 1f))
                    {
                        this.currentVehicle.refuel();
                    }
                    else if (this.manualRefuel)
                    {
                        this.currentVehicle.refuel();
                    }
                    break;
                }
            }
        }

        private bool vehicleUsesFuel()
        {
            bool flag;
            InputArgument[] currentVehicle = new InputArgument[] { this.pedCurrentPlayer };
            if (!Function.Call<bool>(6917332199840217984L, currentVehicle))
            {
                currentVehicle = new InputArgument[] { this.pedCurrentPlayer.get_CurrentVehicle(), -1 };
                if (Function.Call<Ped>(-4953716450117921946L, currentVehicle) == this.pedCurrentPlayer)
                {
                    currentVehicle = new InputArgument[1];
                    Model model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                    currentVehicle[0] = model.get_Hash();
                    if (!Function.Call<bool>(-4641842036243439918L, currentVehicle))
                    {
                        currentVehicle = new InputArgument[1];
                        model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                        currentVehicle[0] = model.get_Hash();
                        if (!Function.Call<bool>(5019570168338364899L, currentVehicle))
                        {
                            currentVehicle = new InputArgument[1];
                            model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                            currentVehicle[0] = model.get_Hash();
                            if (!Function.Call<bool>(-2529840708346473238L, currentVehicle))
                            {
                                currentVehicle = new InputArgument[1];
                                model = this.pedCurrentPlayer.get_CurrentVehicle().get_Model();
                                currentVehicle[0] = model.get_Hash();
                                flag = (!Function.Call<bool>(-6083429105704992213L, currentVehicle) ? true : false);
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = true;
            }
            return flag;
        }
    }
}