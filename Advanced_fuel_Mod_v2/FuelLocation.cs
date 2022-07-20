using GTA.Math;
using System;

namespace Advanced_Fuel_Mod_v2
{
    internal class FuelLocation
    {
        public float x;

        public float y;

        public float z;

        public bool showBlip = true;

        public bool isElectric = false;

        public float range = 12f;

        public FuelLocation(float newX, float newY, float newZ, bool newShowBlip)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
            this.showBlip = newShowBlip;
        }

        public FuelLocation(string s, float customRange, bool electric)
        {
            string[] strArrays = s.Split(new char[] { ',' });
            this.x = float.Parse(strArrays[0].Trim());
            this.y = float.Parse(strArrays[1].Trim());
            this.z = float.Parse(strArrays[2].Trim());
            this.showBlip = strArrays[3].Trim().ToUpper().Equals("TRUE");
            this.range = customRange;
            this.isElectric = electric;
        }

        public FuelLocation(Vector3 FuelPoint, bool showBlip)
        {
            this.x = FuelPoint.X;
            this.y = FuelPoint.Y;
            this.z = FuelPoint.Z;
            this.showBlip = showBlip;
        }

        public FuelLocation(Vector3 FuelPoint, bool showBlip, bool isElectric)
        {
            this.x = FuelPoint.X;
            this.y = FuelPoint.Y;
            this.z = FuelPoint.Z;
            this.showBlip = showBlip;
            this.isElectric = isElectric;
            if (isElectric)
            {
                this.range = 5f;
            }
        }

        public FuelLocation(Vector3 FuelPoint, bool showBlip, bool isElectric, float range)
        {
            this.x = FuelPoint.X;
            this.y = FuelPoint.Y;
            this.z = FuelPoint.Z;
            this.showBlip = showBlip;
            this.isElectric = isElectric;
            this.range = range;
        }
    }
}