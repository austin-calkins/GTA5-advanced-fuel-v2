using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;

namespace Advanced_Fuel_Mod_v2
{
    public class FuelledVehicle
    {
        public Vehicle vehicle;

        public float fuelPercentage;

        public float tankSize = 60f;

        public float oldAltitude;

        public float oldSpeed;

        public bool isRefuelling = false;

        public float oldFuelLevel;

        public float instFC;

        public float distance;

        public bool cutEngine = false;

        private bool vehicleUsesFuel = true;

        public bool isElectric;

        public bool isHyrbid;

        private Vector3 oldPos;

        public float topSpeed = 0f;

        public float chargeLevel;

        public float chargeCapacity;

        public int handle;

        public List<float> avgFuelConsumption = new List<float>();

        public List<float> avgSpeed = new List<float>();

        public float distanceSinceLastRefuel;

        public float fuelUsedSinceLastRefuel;

        public FuelledVehicle.vehicleType type;

        public FuelledVehicle(Vehicle v)
        {
            Exception exception;
            this.vehicle = v;
            int num = (new Random()).Next(15, 90);
            this.fuelPercentage = (float)num / 100f;
            this.chargeLevel = this.fuelPercentage;
            this.oldPos = v.get_Position();
            this.handle = v.get_Handle();
            this.isElectric = false;
            this.isHyrbid = false;
            if (CONSTANTS.electricVehicles.Contains(v.get_DisplayName().ToLower()))
            {
                this.isElectric = true;
                this.chargeLevel = 0.5f;
            }
            if (CONSTANTS.hybridVehicles.Contains(v.get_DisplayName().ToLower()))
            {
                this.isHyrbid = true;
            }
            this.type = this.getVehicleType(v);
            if (!this.isElectric)
            {
                try
                {
                    this.tankSize = (float)CONSTANTS.fuelTankSizes[v.get_DisplayName().ToLower()];
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    this.tankSize = 60f;
                }
            }
            else
            {
                try
                {
                    this.tankSize = CONSTANTS.batterySizes[v.get_DisplayName().ToLower()];
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    this.tankSize = 20f;
                }
            }
        }

        private float getInstFuelConsumption(bool useImperial)
        {
            float single;
            bool flag;
            if (this.isElectric)
            {
                if (this.vehicle.get_CurrentRPM() == 0f)
                {
                    single = 0f;
                    return single;
                }
            }
            InputArgument[] x = new InputArgument[] { (float)this.vehicle.get_Position().X, (float)this.vehicle.get_Position().Y, (float)this.vehicle.get_Position().Z, (float)this.oldPos.X, (float)this.oldPos.Y, (float)this.oldPos.Z };
            if (Function.Call<float>(-5919598598998941289L, x) <= 200f)
            {
                x = new InputArgument[] { this.vehicle };
                float single1 = (float)Function.Call<float>(6760849226395965358L, x) * 25f;
                float single2 = 1f;
                float speed = (float)this.vehicle.get_Speed() - this.oldSpeed;
                this.oldSpeed = this.vehicle.get_Speed();
                if (speed > 0f)
                {
                    single2 = single2 + speed * 75f;
                }
                Model model = this.vehicle.get_Model();
                float volume = this.getVolume(model.GetDimensions());
                single2 += (float)((double)(volume - 14.54798f) * 0.1);
                if (single1 * single2 >= 0f)
                {
                    x = new InputArgument[1];
                    model = this.vehicle.get_Model();
                    x[0] = model.get_Hash();
                    if (!Function.Call<bool>(5019570168338364899L, x))
                    {
                        x = new InputArgument[1];
                        model = this.vehicle.get_Model();
                        x[0] = model.get_Hash();
                        if (Function.Call<bool>(-2529840708346473238L, x))
                        {
                            flag = false;
                        }
                        else
                        {
                            x = new InputArgument[1];
                            model = this.vehicle.get_Model();
                            x[0] = model.get_Hash();
                            flag = !Function.Call<bool>(-6875718224626081570L, x);
                        }
                        single = (flag ? single1 * single2 : single1 * single2 / 10f);
                    }
                    else
                    {
                        single = single1 * single2 / 10f;
                    }
                }
                else
                {
                    single = single1 * 0.3f;
                }
            }
            else
            {
                single = 0f;
            }
            return single;
        }

        private FuelledVehicle.vehicleType getVehicleType(Vehicle v)
        {
            FuelledVehicle.vehicleType _vehicleType;
            if (!this.isElectric)
            {
                InputArgument[] hash = new InputArgument[1];
                Model model = v.get_Model();
                hash[0] = model.get_Hash();
                if (!Function.Call<bool>(-6875718224626081570L, hash))
                {
                    hash = new InputArgument[1];
                    model = v.get_Model();
                    hash[0] = model.get_Hash();
                    if (!Function.Call<bool>(5019570168338364899L, hash))
                    {
                        hash = new InputArgument[1];
                        model = v.get_Model();
                        hash[0] = model.get_Hash();
                        if (!Function.Call<bool>(-2529840708346473238L, hash))
                        {
                            hash = new InputArgument[1];
                            model = v.get_Model();
                            hash[0] = model.get_Hash();
                            if (!Function.Call<bool>(-5400929702967325052L, hash))
                            {
                                hash = new InputArgument[1];
                                model = v.get_Model();
                                hash[0] = model.get_Hash();
                                _vehicleType = (!Function.Call<bool>(4168859234758687272L, hash) ? FuelledVehicle.vehicleType.car : FuelledVehicle.vehicleType.bike);
                            }
                            else
                            {
                                _vehicleType = FuelledVehicle.vehicleType.bike;
                            }
                        }
                        else
                        {
                            _vehicleType = FuelledVehicle.vehicleType.helicopter;
                        }
                    }
                    else
                    {
                        _vehicleType = FuelledVehicle.vehicleType.boat;
                    }
                }
                else
                {
                    _vehicleType = FuelledVehicle.vehicleType.plane;
                }
            }
            else
            {
                _vehicleType = FuelledVehicle.vehicleType.electric;
            }
            return _vehicleType;
        }

        public float getVolume(Vector3 v)
        {
            return v.X * v.Y * v.Z;
        }

        public void refuel()
        {
            this.isRefuelling = true;
            this.oldFuelLevel = this.fuelPercentage;
        }

        public void resetTripComputer()
        {
            this.distance = 0f;
            this.avgFuelConsumption.Clear();
            this.avgSpeed.Clear();
        }

        internal void stopRefuelling(float price, Player p)
        {
            this.isRefuelling = false;
            float single = (float)(this.fuelPercentage - this.oldFuelLevel) * this.tankSize * price;
            Function.Call(-7575396704912799561L, new InputArgument[] { true });
            p.set_Money(p.get_Money() - (int)single);
            this.vehicle.set_EngineRunning(true);
            Script.Wait(500);
            this.distanceSinceLastRefuel = 0f;
            this.fuelUsedSinceLastRefuel = 0f;
        }

        public void toggleEnableFuelUsage()
        {
            this.vehicleUsesFuel = !this.vehicleUsesFuel;
        }

        public void update(float price, Player p, bool useImperial, Ped player)
        {
            float single;
            InputArgument[] x;
            bool flag;
            bool flag1;
            if (this.cutEngine)
            {
                this.vehicle.set_EngineRunning(false);
            }
            if (!this.isRefuelling)
            {
                if (this.fuelPercentage <= 0f || this.isElectric)
                {
                    flag = (this.chargeLevel <= 0f ? true : !this.isElectric);
                }
                else
                {
                    flag = false;
                }
                if (!flag)
                {
                    x = new InputArgument[] { this.vehicle };
                    if ((Function.Call<float>(9033565442791362676L, x) >= 650f ? false : UserSettings.useMoreFuelWhenLeaking))
                    {
                        if (this.vehicleUsesFuel)
                        {
                            if (!this.isElectric)
                            {
                                this.fuelPercentage -= 1E-05f;
                            }
                        }
                    }
                    float instFuelConsumption = this.getInstFuelConsumption(useImperial);
                    if (this.vehicle.get_DisplayName().ToUpper().Equals("BLIMP"))
                    {
                        instFuelConsumption /= 1100f;
                    }
                    x = new InputArgument[] { (float)this.oldPos.X, (float)this.oldPos.Y, (float)this.oldPos.Z, (float)this.vehicle.get_Position().X, (float)this.vehicle.get_Position().Y, (float)this.vehicle.get_Position().Z };
                    float single1 = Function.Call<float>(-1029247852194248366L, x);
                    float single2 = (float)single1 / 1000f;
                    this.distance += single2;
                    this.distanceSinceLastRefuel += single2;
                    if (single1 > 0f)
                    {
                        float single3 = (float)(instFuelConsumption / 100f * single2);
                        if (this.vehicleUsesFuel)
                        {
                            if (!this.isElectric)
                            {
                                FuelledVehicle fuelledVehicle = this;
                                fuelledVehicle.fuelPercentage = fuelledVehicle.fuelPercentage - single3 / this.tankSize;
                            }
                            else if ((this.vehicle.get_Acceleration() >= 0f ? true : !this.vehicle.IsInBurnout()))
                            {
                                this.chargeLevel -= (float)(instFuelConsumption / 100f * single2);
                                this.fuelUsedSinceLastRefuel += (float)(instFuelConsumption / 100f * single2);
                            }
                        }
                    }
                    this.instFC = instFuelConsumption;
                    this.avgFuelConsumption.Insert(0, instFuelConsumption);
                    int num = 10000;
                    if (this.avgFuelConsumption.Count > num)
                    {
                        this.avgFuelConsumption.RemoveRange(num, this.avgFuelConsumption.Count - num);
                    }
                    this.avgSpeed.Insert(0, (float)((double)this.vehicle.get_Speed() * 3.6));
                    if (this.avgSpeed.Count > num)
                    {
                        this.avgSpeed.RemoveRange(num, this.avgSpeed.Count - num);
                    }
                    if ((double)this.vehicle.get_Speed() * 3.6 > (double)this.topSpeed)
                    {
                        this.topSpeed = (float)(this.vehicle.get_Speed() * 3.6f);
                    }
                    this.oldPos = this.vehicle.get_Position();
                }
                if (this.isElectric || this.fuelPercentage > 0f)
                {
                    flag1 = (!this.isElectric ? true : this.chargeLevel > 0f);
                }
                else
                {
                    flag1 = false;
                }
                if (!flag1)
                {
                    this.vehicle.set_EngineRunning(false);
                }
            }
            else
            {
                this.vehicle.set_EngineRunning(false);
                if (this.isElectric)
                {
                    if (this.chargeLevel >= 1f)
                    {
                        this.isRefuelling = false;
                        single = (float)(1f - this.oldFuelLevel) * this.tankSize * price;
                        x = new InputArgument[] { true };
                        Function.Call(-7575396704912799561L, x);
                        p.set_Money(p.get_Money() - (int)single);
                        this.vehicle.set_EngineRunning(true);
                        this.distanceSinceLastRefuel = 0f;
                        this.fuelUsedSinceLastRefuel = 0f;
                    }
                    else
                    {
                        this.chargeLevel += CONSTANTS.flowRateElectric;
                    }
                }
                else if (this.fuelPercentage >= 1f)
                {
                    this.isRefuelling = false;
                    single = (float)(1f - this.oldFuelLevel) * this.tankSize * price;
                    x = new InputArgument[] { true };
                    Function.Call(-7575396704912799561L, x);
                    p.set_Money(p.get_Money() - (int)single);
                    this.vehicle.set_EngineRunning(true);
                    this.distanceSinceLastRefuel = 0f;
                    this.fuelUsedSinceLastRefuel = 0f;
                }
                else
                {
                    float single4 = CONSTANTS.flowRateCar;
                    if (this.type == FuelledVehicle.vehicleType.bike)
                    {
                        single4 = CONSTANTS.flowRateCar;
                    }
                    else if (this.type == FuelledVehicle.vehicleType.boat)
                    {
                        single4 = CONSTANTS.flowRateDock;
                    }
                    else if (this.type == FuelledVehicle.vehicleType.helicopter)
                    {
                        single4 = CONSTANTS.flowRateHeli;
                    }
                    else if (this.type == FuelledVehicle.vehicleType.plane)
                    {
                        single4 = CONSTANTS.flowRatePlane;
                    }
                    this.fuelPercentage += Converter.convertLitresToPercentage(single4, this.tankSize);
                }
            }
        }

        public enum vehicleType
        {
            car = 1,
            bike = 2,
            boat = 3,
            helicopter = 4,
            plane = 5,
            submarine = 6,
            electric = 7
        }
    }
}