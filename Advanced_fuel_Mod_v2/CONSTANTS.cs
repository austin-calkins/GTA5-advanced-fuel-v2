using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;

namespace Advanced_Fuel_Mod_v2
{
    public class CONSTANTS
    {
        public static string unitsPerHour;

        public static string fuelConsumptionUnits;

        public static string distanceUnits;

        public static string LiquidUnits;

        public static Dictionary<string, int> fuelTankSizes;

        public static Dictionary<string, float> batterySizes;

        public static List<string> electricVehicles;

        public static List<string> hybridVehicles;

        public static List<Vector3> electricFuelPoints;

        public static List<TextElement> textElements;

        public static float flowRateCar;

        public static float flowRateDock;

        public static float flowRateHeli;

        public static float flowRatePlane;

        public static float flowRateElectric;

        static CONSTANTS()
        {
            CONSTANTS.unitsPerHour = "km/h";
            CONSTANTS.fuelConsumptionUnits = "L/100km";
            CONSTANTS.distanceUnits = "Kilometers";
            CONSTANTS.LiquidUnits = "L";
            CONSTANTS.fuelTankSizes = new Dictionary<string, int>();
            CONSTANTS.batterySizes = new Dictionary<string, float>();
            CONSTANTS.electricVehicles = new List<string>();
            CONSTANTS.hybridVehicles = new List<string>();
            CONSTANTS.electricFuelPoints = new List<Vector3>();
            CONSTANTS.textElements = new List<TextElement>();
            CONSTANTS.flowRateCar = 0.1f;
            CONSTANTS.flowRateDock = 0.5f;
            CONSTANTS.flowRateHeli = 1f;
            CONSTANTS.flowRatePlane = 5f;
            CONSTANTS.flowRateElectric = 0.0001f;
        }

        public CONSTANTS()
        {
        }

        public static void loadBatterySizes()
        {
            CONSTANTS.batterySizes.Add("zentorno", 4.7f);
            CONSTANTS.batterySizes.Add("turismor", 4.7f);
            CONSTANTS.batterySizes.Add("khamelion", 4.7f);
            CONSTANTS.batterySizes.Add("dilettante", 4.4f);
            CONSTANTS.batterySizes.Add("dilettante2", 4.4f);
            CONSTANTS.batterySizes.Add("t20", 4.7f);
            CONSTANTS.batterySizes.Add("voltic", 56f);
            CONSTANTS.batterySizes.Add("surge", 16f);
            CONSTANTS.batterySizes.Add("caddy", 10f);
            CONSTANTS.batterySizes.Add("caddy2", 10f);
            CONSTANTS.batterySizes.Add("airtug", 20f);
        }

        public static void loadElectricFuelPoints()
        {
            CONSTANTS.electricFuelPoints.Add(new Vector3(1205.322f, 2644.746f, 37.0804f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(2683.121f, 3292.003f, 54.47284f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(2555.516f, 345.944f, 107.7038f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(1169.184f, -316.9469f, 68.41484f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(1217.981f, -1385.525f, 34.39091f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(811.6792f, -1044.563f, 25.87364f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(283.5654f, -1276.125f, 29.30064f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(-51.65789f, -1761.781f, 29.16256f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(-545.4564f, -1222.023f, 17.57847f));
            CONSTANTS.electricFuelPoints.Add(new Vector3(-2079.063f, -335.2959f, 12.43466f));
        }

        public static void loadElectricVehicles()
        {
            CONSTANTS.electricVehicles.Add("voltic");
            CONSTANTS.electricVehicles.Add("surge");
            CONSTANTS.electricVehicles.Add("caddy");
            CONSTANTS.electricVehicles.Add("caddy2");
            CONSTANTS.electricVehicles.Add("airtug");
            CONSTANTS.hybridVehicles.Add("zentorno");
            CONSTANTS.hybridVehicles.Add("turismor");
            CONSTANTS.hybridVehicles.Add("khamelion");
            CONSTANTS.hybridVehicles.Add("dilettante");
            CONSTANTS.hybridVehicles.Add("dilettante2");
            CONSTANTS.hybridVehicles.Add("t20");
        }

        public static void loadFuelTanks()
        {
            int num = 15;
            CONSTANTS.batterySizes.Add("adder", 100f);
            CONSTANTS.batterySizes.Add("airbus", 400f);
            CONSTANTS.batterySizes.Add("airtug", 60f);
            CONSTANTS.batterySizes.Add("akuma", (float)num);
            CONSTANTS.batterySizes.Add("ambulance", 150f);
            CONSTANTS.batterySizes.Add("annihilator", 2500f);
            CONSTANTS.batterySizes.Add("armytanker", 60f);
            CONSTANTS.batterySizes.Add("armytrailer", 60f);
            CONSTANTS.batterySizes.Add("armytrailer2", 60f);
            CONSTANTS.batterySizes.Add("asea", 50f);
            CONSTANTS.batterySizes.Add("asea2", 50f);
            CONSTANTS.batterySizes.Add("asterope", 50f);
            CONSTANTS.batterySizes.Add("bagger", (float)(num + 5));
            CONSTANTS.batterySizes.Add("baletrailer", 60f);
            CONSTANTS.batterySizes.Add("baller", 100f);
            CONSTANTS.batterySizes.Add("baller2", 100f);
            CONSTANTS.batterySizes.Add("banshee", 60f);
            CONSTANTS.batterySizes.Add("barracks", 300f);
            CONSTANTS.batterySizes.Add("barracks2", 300f);
            CONSTANTS.batterySizes.Add("bati", (float)num);
            CONSTANTS.batterySizes.Add("bati2", (float)num);
            CONSTANTS.batterySizes.Add("benson", 150f);
            CONSTANTS.batterySizes.Add("bfinjection", 60f);
            CONSTANTS.batterySizes.Add("biff", 150f);
            CONSTANTS.batterySizes.Add("bison", 130f);
            CONSTANTS.batterySizes.Add("bison2", 130f);
            CONSTANTS.batterySizes.Add("bison3", 130f);
            CONSTANTS.batterySizes.Add("bjxl", 150f);
            CONSTANTS.batterySizes.Add("blazer", (float)num);
            CONSTANTS.batterySizes.Add("blazer2", (float)num);
            CONSTANTS.batterySizes.Add("blazer3", (float)num);
            CONSTANTS.batterySizes.Add("blimp", 300f);
            CONSTANTS.batterySizes.Add("blista", 50f);
            CONSTANTS.batterySizes.Add("bmx", 60f);
            CONSTANTS.batterySizes.Add("boattrailer", 60f);
            CONSTANTS.batterySizes.Add("bobcatxl", 130f);
            CONSTANTS.batterySizes.Add("bodhi2", 70f);
            CONSTANTS.batterySizes.Add("boxville", 55f);
            CONSTANTS.batterySizes.Add("boxville2", 55f);
            CONSTANTS.batterySizes.Add("boxville3", 55f);
            CONSTANTS.batterySizes.Add("buccaneer", 80f);
            CONSTANTS.batterySizes.Add("buffalo", 75f);
            CONSTANTS.batterySizes.Add("buffalo2", 75f);
            CONSTANTS.batterySizes.Add("bulldozer", 1900f);
            CONSTANTS.batterySizes.Add("bullet", 65f);
            CONSTANTS.batterySizes.Add("burrito", 120f);
            CONSTANTS.batterySizes.Add("burrito2", 120f);
            CONSTANTS.batterySizes.Add("burrito3", 120f);
            CONSTANTS.batterySizes.Add("burrito4", 120f);
            CONSTANTS.batterySizes.Add("burrito5", 120f);
            CONSTANTS.batterySizes.Add("bus", 400f);
            CONSTANTS.batterySizes.Add("buzzard", 300f);
            CONSTANTS.batterySizes.Add("buzzard2", 300f);
            CONSTANTS.batterySizes.Add("cablecar", 60f);
            CONSTANTS.batterySizes.Add("caddy", 20f);
            CONSTANTS.batterySizes.Add("caddy2", 20f);
            CONSTANTS.batterySizes.Add("camper", 130f);
            CONSTANTS.batterySizes.Add("carbonizzare", 80f);
            CONSTANTS.batterySizes.Add("carbonrs", (float)num);
            CONSTANTS.batterySizes.Add("cargobob", 1500f);
            CONSTANTS.batterySizes.Add("cargobob2", 1500f);
            CONSTANTS.batterySizes.Add("cargobob3", 1500f);
            CONSTANTS.batterySizes.Add("cargopl", 200000f);
            CONSTANTS.batterySizes.Add("cavalcade", 100f);
            CONSTANTS.batterySizes.Add("cavalcade2", 100f);
            CONSTANTS.batterySizes.Add("cheetah", 110f);
            CONSTANTS.batterySizes.Add("coach", 60f);
            CONSTANTS.batterySizes.Add("cogcabrio", 90f);
            CONSTANTS.batterySizes.Add("comet2", 65f);
            CONSTANTS.batterySizes.Add("coquette", 70f);
            CONSTANTS.batterySizes.Add("cruiser", 60f);
            CONSTANTS.batterySizes.Add("crusader", 85f);
            CONSTANTS.batterySizes.Add("cuban800", 780f);
            CONSTANTS.batterySizes.Add("cutter", 60f);
            CONSTANTS.batterySizes.Add("daemon", (float)num);
            CONSTANTS.batterySizes.Add("dilettante", 50f);
            CONSTANTS.batterySizes.Add("dilettante2", 50f);
            CONSTANTS.batterySizes.Add("dinghy", 280f);
            CONSTANTS.batterySizes.Add("dinghy2", 280f);
            CONSTANTS.batterySizes.Add("dloader", 75f);
            CONSTANTS.batterySizes.Add("docktrailer", 60f);
            CONSTANTS.batterySizes.Add("docktug", 230f);
            CONSTANTS.batterySizes.Add("dominator", 60f);
            CONSTANTS.batterySizes.Add("double", (float)num);
            CONSTANTS.batterySizes.Add("dubsta", 100f);
            CONSTANTS.batterySizes.Add("dubsta2", 100f);
            CONSTANTS.batterySizes.Add("dump", 4500f);
            CONSTANTS.batterySizes.Add("dune", 45f);
            CONSTANTS.batterySizes.Add("dune2", 45f);
            CONSTANTS.batterySizes.Add("duster", 160f);
            CONSTANTS.batterySizes.Add("elegy2", 75f);
            CONSTANTS.batterySizes.Add("emperor", 90f);
            CONSTANTS.batterySizes.Add("emperor2", 90f);
            CONSTANTS.batterySizes.Add("emperor3", 90f);
            CONSTANTS.batterySizes.Add("entityxf", 80f);
            CONSTANTS.batterySizes.Add("exemplar", 80f);
            CONSTANTS.batterySizes.Add("f620", 90f);
            CONSTANTS.batterySizes.Add("faggio2", (float)num);
            CONSTANTS.batterySizes.Add("fbi", 60f);
            CONSTANTS.batterySizes.Add("fbi2", 60f);
            CONSTANTS.batterySizes.Add("felon", 70f);
            CONSTANTS.batterySizes.Add("felon2", 70f);
            CONSTANTS.batterySizes.Add("feltzer2", 70f);
            CONSTANTS.batterySizes.Add("firetruk", 200f);
            CONSTANTS.batterySizes.Add("fixter", 60f);
            CONSTANTS.batterySizes.Add("flatbed", 300f);
            CONSTANTS.batterySizes.Add("forklift", 45f);
            CONSTANTS.batterySizes.Add("fq2", 90f);
            CONSTANTS.batterySizes.Add("freight", 60f);
            CONSTANTS.batterySizes.Add("freightcar", 60f);
            CONSTANTS.batterySizes.Add("freightcont1", 60f);
            CONSTANTS.batterySizes.Add("freightcont2", 60f);
            CONSTANTS.batterySizes.Add("freightgrain", 60f);
            CONSTANTS.batterySizes.Add("freighttrailer", 60f);
            CONSTANTS.batterySizes.Add("frogger", 600f);
            CONSTANTS.batterySizes.Add("frogger2", 600f);
            CONSTANTS.batterySizes.Add("fugitive", 70f);
            CONSTANTS.batterySizes.Add("fusilade", 60f);
            CONSTANTS.batterySizes.Add("futo", 50f);
            CONSTANTS.batterySizes.Add("gauntlet", 70f);
            CONSTANTS.batterySizes.Add("gburrito", 60f);
            CONSTANTS.batterySizes.Add("graintrailer", 60f);
            CONSTANTS.batterySizes.Add("granger", 120f);
            CONSTANTS.batterySizes.Add("gresley", 90f);
            CONSTANTS.batterySizes.Add("habanero", 70f);
            CONSTANTS.batterySizes.Add("handler", 1000f);
            CONSTANTS.batterySizes.Add("hauler", 400f);
            CONSTANTS.batterySizes.Add("hexer", (float)num);
            CONSTANTS.batterySizes.Add("hotknife", 40f);
            CONSTANTS.batterySizes.Add("infernus", 90f);
            CONSTANTS.batterySizes.Add("ingot", 70f);
            CONSTANTS.batterySizes.Add("intruder", 80f);
            CONSTANTS.batterySizes.Add("issi2", 40f);
            CONSTANTS.batterySizes.Add("jackal", 70f);
            CONSTANTS.batterySizes.Add("jb700", 85f);
            CONSTANTS.batterySizes.Add("jet", 183380f);
            CONSTANTS.batterySizes.Add("jetmax", 300f);
            CONSTANTS.batterySizes.Add("journey", 180f);
            CONSTANTS.batterySizes.Add("khamelion", 80f);
            CONSTANTS.batterySizes.Add("landstalker", 105f);
            CONSTANTS.batterySizes.Add("lazer", 4000f);
            CONSTANTS.batterySizes.Add("lguard", 60f);
            CONSTANTS.batterySizes.Add("luxor", 3000f);
            CONSTANTS.batterySizes.Add("mammatus", 300f);
            CONSTANTS.batterySizes.Add("manana", 100f);
            CONSTANTS.batterySizes.Add("marquis", 75f);
            CONSTANTS.batterySizes.Add("maverick", 600f);
            CONSTANTS.batterySizes.Add("mesa", 85f);
            CONSTANTS.batterySizes.Add("mesa2", 85f);
            CONSTANTS.batterySizes.Add("mesa3", 85f);
            CONSTANTS.batterySizes.Add("metrotrain", 60f);
            CONSTANTS.batterySizes.Add("minivan", 75f);
            CONSTANTS.batterySizes.Add("mixer", 300f);
            CONSTANTS.batterySizes.Add("mixer2", 300f);
            CONSTANTS.batterySizes.Add("monroe", 90f);
            CONSTANTS.batterySizes.Add("mower", 20f);
            CONSTANTS.batterySizes.Add("mule", 60f);
            CONSTANTS.batterySizes.Add("mule2", 60f);
            CONSTANTS.batterySizes.Add("nemesis", (float)num);
            CONSTANTS.batterySizes.Add("ninef", 100f);
            CONSTANTS.batterySizes.Add("ninef2", 100f);
            CONSTANTS.batterySizes.Add("oracle", 90f);
            CONSTANTS.batterySizes.Add("oracle2", 90f);
            CONSTANTS.batterySizes.Add("packer", 400f);
            CONSTANTS.batterySizes.Add("patriot", 120f);
            CONSTANTS.batterySizes.Add("pbus", 400f);
            CONSTANTS.batterySizes.Add("pcj", (float)num);
            CONSTANTS.batterySizes.Add("penumbra", 70f);
            CONSTANTS.batterySizes.Add("peyote", 80f);
            CONSTANTS.batterySizes.Add("phantom", 450f);
            CONSTANTS.batterySizes.Add("phoenix", 75f);
            CONSTANTS.batterySizes.Add("picador", 80f);
            CONSTANTS.batterySizes.Add("police", 70f);
            CONSTANTS.batterySizes.Add("police2", 75f);
            CONSTANTS.batterySizes.Add("police3", 75f);
            CONSTANTS.batterySizes.Add("police4", 75f);
            CONSTANTS.batterySizes.Add("policeb", (float)(num + 5));
            CONSTANTS.batterySizes.Add("policeold1", 110f);
            CONSTANTS.batterySizes.Add("policeold2", 70f);
            CONSTANTS.batterySizes.Add("policet", 60f);
            CONSTANTS.batterySizes.Add("polmav", 350f);
            CONSTANTS.batterySizes.Add("pony", 120f);
            CONSTANTS.batterySizes.Add("pony2", 120f);
            CONSTANTS.batterySizes.Add("pounder", 400f);
            CONSTANTS.batterySizes.Add("prairie", 55f);
            CONSTANTS.batterySizes.Add("pranger", 60f);
            CONSTANTS.batterySizes.Add("predator", 300f);
            CONSTANTS.batterySizes.Add("premier", 50f);
            CONSTANTS.batterySizes.Add("primo", 80f);
            CONSTANTS.batterySizes.Add("proptrailer", 60f);
            CONSTANTS.batterySizes.Add("radi", 70f);
            CONSTANTS.batterySizes.Add("raketrailer", 60f);
            CONSTANTS.batterySizes.Add("rancherxl", 100f);
            CONSTANTS.batterySizes.Add("rancherxl2", 100f);
            CONSTANTS.batterySizes.Add("rapidgt", 80f);
            CONSTANTS.batterySizes.Add("rapidgt2", 80f);
            CONSTANTS.batterySizes.Add("ratloader", 50f);
            CONSTANTS.batterySizes.Add("rebel", 100f);
            CONSTANTS.batterySizes.Add("rebel2", 100f);
            CONSTANTS.batterySizes.Add("regina", 95f);
            CONSTANTS.batterySizes.Add("rentalbus", 120f);
            CONSTANTS.batterySizes.Add("rhino", 1200f);
            CONSTANTS.batterySizes.Add("riot", 60f);
            CONSTANTS.batterySizes.Add("ripley", 200f);
            CONSTANTS.batterySizes.Add("rocoto", 100f);
            CONSTANTS.batterySizes.Add("romero", 70f);
            CONSTANTS.batterySizes.Add("rubble", 400f);
            CONSTANTS.batterySizes.Add("ruffian", (float)num);
            CONSTANTS.batterySizes.Add("ruiner", 80f);
            CONSTANTS.batterySizes.Add("rumpo", 120f);
            CONSTANTS.batterySizes.Add("rumpo2", 120f);
            CONSTANTS.batterySizes.Add("sabregt", 60f);
            CONSTANTS.batterySizes.Add("sadler", 130f);
            CONSTANTS.batterySizes.Add("sadler2", 130f);
            CONSTANTS.batterySizes.Add("sanchez", (float)num);
            CONSTANTS.batterySizes.Add("sanchez2", (float)num);
            CONSTANTS.batterySizes.Add("sandking", 100f);
            CONSTANTS.batterySizes.Add("sandking2", 100f);
            CONSTANTS.batterySizes.Add("schafter2", 80f);
            CONSTANTS.batterySizes.Add("schwarzer", 80f);
            CONSTANTS.batterySizes.Add("scorcher", 60f);
            CONSTANTS.batterySizes.Add("scrap", 400f);
            CONSTANTS.batterySizes.Add("seashark", 50f);
            CONSTANTS.batterySizes.Add("seashark2", 50f);
            CONSTANTS.batterySizes.Add("seminole", 95f);
            CONSTANTS.batterySizes.Add("sentinel", 70f);
            CONSTANTS.batterySizes.Add("sentinel2", 70f);
            CONSTANTS.batterySizes.Add("serrano", 90f);
            CONSTANTS.batterySizes.Add("shamal", 3000f);
            CONSTANTS.batterySizes.Add("sheriff", 60f);
            CONSTANTS.batterySizes.Add("sheriff2", 60f);
            CONSTANTS.batterySizes.Add("skylift", 3300f);
            CONSTANTS.batterySizes.Add("speedo", 120f);
            CONSTANTS.batterySizes.Add("speedo2", 120f);
            CONSTANTS.batterySizes.Add("squalo", 300f);
            CONSTANTS.batterySizes.Add("stanier", 70f);
            CONSTANTS.batterySizes.Add("stinger", 100f);
            CONSTANTS.batterySizes.Add("stingergt", 100f);
            CONSTANTS.batterySizes.Add("stockade", 200f);
            CONSTANTS.batterySizes.Add("stockade3", 60f);
            CONSTANTS.batterySizes.Add("stratum", 65f);
            CONSTANTS.batterySizes.Add("stretch", 70f);
            CONSTANTS.batterySizes.Add("stunt", 300f);
            CONSTANTS.batterySizes.Add("submersible", 0f);
            CONSTANTS.batterySizes.Add("sultan", 50f);
            CONSTANTS.batterySizes.Add("suntrap", 300f);
            CONSTANTS.batterySizes.Add("superd", 100f);
            CONSTANTS.batterySizes.Add("surano", 85f);
            CONSTANTS.batterySizes.Add("surfer", 60f);
            CONSTANTS.batterySizes.Add("surfer2", 60f);
            CONSTANTS.batterySizes.Add("surge", 60f);
            CONSTANTS.batterySizes.Add("taco", 80f);
            CONSTANTS.batterySizes.Add("tailgater", 75f);
            CONSTANTS.batterySizes.Add("tanker", 60f);
            CONSTANTS.batterySizes.Add("tankercar", 60f);
            CONSTANTS.batterySizes.Add("taxi", 70f);
            CONSTANTS.batterySizes.Add("tiptruck", 400f);
            CONSTANTS.batterySizes.Add("tiptruck2", 400f);
            CONSTANTS.batterySizes.Add("titan", 25362f);
            CONSTANTS.batterySizes.Add("tornado", 60f);
            CONSTANTS.batterySizes.Add("tornado2", 60f);
            CONSTANTS.batterySizes.Add("tornado3", 60f);
            CONSTANTS.batterySizes.Add("tornado4", 60f);
            CONSTANTS.batterySizes.Add("tourbus", 120f);
            CONSTANTS.batterySizes.Add("towtruck", 400f);
            CONSTANTS.batterySizes.Add("towtruck2", 90f);
            CONSTANTS.batterySizes.Add("tr2", 60f);
            CONSTANTS.batterySizes.Add("tr3", 60f);
            CONSTANTS.batterySizes.Add("tr4", 60f);
            CONSTANTS.batterySizes.Add("tractor", 40f);
            CONSTANTS.batterySizes.Add("tractor2", 300f);
            CONSTANTS.batterySizes.Add("tractor3", 300f);
            CONSTANTS.batterySizes.Add("trailerlogs", 60f);
            CONSTANTS.batterySizes.Add("trailers", 60f);
            CONSTANTS.batterySizes.Add("trailers2", 60f);
            CONSTANTS.batterySizes.Add("trailers3", 60f);
            CONSTANTS.batterySizes.Add("trailersmall", 60f);
            CONSTANTS.batterySizes.Add("trash", 200f);
            CONSTANTS.batterySizes.Add("trflat", 60f);
            CONSTANTS.batterySizes.Add("tribike", 60f);
            CONSTANTS.batterySizes.Add("tribike2", 60f);
            CONSTANTS.batterySizes.Add("tribike3", 60f);
            CONSTANTS.batterySizes.Add("tropic", 300f);
            CONSTANTS.batterySizes.Add("tvtrailer", 60f);
            CONSTANTS.batterySizes.Add("utillitruck", 60f);
            CONSTANTS.batterySizes.Add("utillitruck2", 60f);
            CONSTANTS.batterySizes.Add("utillitruck3", 60f);
            CONSTANTS.batterySizes.Add("vacca", 90f);
            CONSTANTS.batterySizes.Add("vader", (float)num);
            CONSTANTS.batterySizes.Add("velum", 780f);
            CONSTANTS.batterySizes.Add("vigero", 70f);
            CONSTANTS.batterySizes.Add("voltic", 60f);
            CONSTANTS.batterySizes.Add("voodoo2", 90f);
            CONSTANTS.batterySizes.Add("washington", 70f);
            CONSTANTS.batterySizes.Add("youga", 130f);
            CONSTANTS.batterySizes.Add("zion", 70f);
            CONSTANTS.batterySizes.Add("zion2", 70f);
            CONSTANTS.batterySizes.Add("ztype", 100f);
            CONSTANTS.batterySizes.Add("bifta", 60f);
            CONSTANTS.batterySizes.Add("kalahari", 25f);
            CONSTANTS.batterySizes.Add("paradise", 120f);
            CONSTANTS.batterySizes.Add("speeder", 300f);
            CONSTANTS.batterySizes.Add("btype", 60f);
            CONSTANTS.batterySizes.Add("jester", 70f);
            CONSTANTS.batterySizes.Add("turismor", 70f);
            CONSTANTS.batterySizes.Add("alpha", 60f);
            CONSTANTS.batterySizes.Add("vestra", 350f);
            CONSTANTS.batterySizes.Add("massacro", 90f);
            CONSTANTS.batterySizes.Add("zentorno", 100f);
            CONSTANTS.batterySizes.Add("huntley", 65f);
            CONSTANTS.batterySizes.Add("thrust", (float)num);
            CONSTANTS.batterySizes.Add("rhapsody", 50f);
            CONSTANTS.batterySizes.Add("warrener", 65f);
            CONSTANTS.batterySizes.Add("blade", 50f);
            CONSTANTS.batterySizes.Add("glendale", 65f);
            CONSTANTS.batterySizes.Add("panto", 40f);
            CONSTANTS.batterySizes.Add("dubsta3", 60f);
            CONSTANTS.batterySizes.Add("pigalle", 100f);
            CONSTANTS.batterySizes.Add("monster", 100f);
            CONSTANTS.batterySizes.Add("sovereign", (float)(num + 5));
            CONSTANTS.batterySizes.Add("besra", 5000f);
            CONSTANTS.batterySizes.Add("miljet", 10000f);
            CONSTANTS.batterySizes.Add("coquette2", 90f);
            CONSTANTS.batterySizes.Add("swift", 550f);
            CONSTANTS.batterySizes.Add("innovation", (float)num);
            CONSTANTS.batterySizes.Add("hakuchou", (float)num);
            CONSTANTS.batterySizes.Add("furoregt", 90f);
            CONSTANTS.batterySizes.Add("jester2", 70f);
            CONSTANTS.batterySizes.Add("massacro2", 90f);
            CONSTANTS.batterySizes.Add("ratloader2", 50f);
            CONSTANTS.batterySizes.Add("slamvan", 60f);
            CONSTANTS.batterySizes.Add("mule3", 60f);
            CONSTANTS.batterySizes.Add("velum2", 60f);
            CONSTANTS.batterySizes.Add("tanker2", 60f);
            CONSTANTS.batterySizes.Add("casco", 80f);
            CONSTANTS.batterySizes.Add("boxville4", 60f);
            CONSTANTS.batterySizes.Add("hydra", 2000f);
            CONSTANTS.batterySizes.Add("insurgent", 250f);
            CONSTANTS.batterySizes.Add("insurgent2", 250f);
            CONSTANTS.batterySizes.Add("gburrito2", 60f);
            CONSTANTS.batterySizes.Add("technical", 90f);
            CONSTANTS.batterySizes.Add("dinghy3", 280f);
            CONSTANTS.batterySizes.Add("savage", 2000f);
            CONSTANTS.batterySizes.Add("enduro", (float)num);
            CONSTANTS.batterySizes.Add("guardian", 200f);
            CONSTANTS.batterySizes.Add("lectro", (float)num);
            CONSTANTS.batterySizes.Add("kuruma", 55f);
            CONSTANTS.batterySizes.Add("kuruma2", 55f);
            CONSTANTS.batterySizes.Add("trash2", 200f);
            CONSTANTS.batterySizes.Add("barracks3", 60f);
            CONSTANTS.batterySizes.Add("valkyrie", 1300f);
            CONSTANTS.batterySizes.Add("slamvan2", 60f);
            CONSTANTS.batterySizes.Add("swift2", 60f);
            CONSTANTS.batterySizes.Add("luxor2", 3000f);
            CONSTANTS.batterySizes.Add("feltzer3", 70f);
            CONSTANTS.batterySizes.Add("osiris", 85f);
            CONSTANTS.batterySizes.Add("virgo", 60f);
            CONSTANTS.batterySizes.Add("windsor", 80f);
            CONSTANTS.batterySizes.Add("submersible2", 0f);
            CONSTANTS.batterySizes.Add("dukes", 70f);
            CONSTANTS.batterySizes.Add("dukes2", 70f);
            CONSTANTS.batterySizes.Add("buffalo3", 75f);
            CONSTANTS.batterySizes.Add("dominator2", 60f);
            CONSTANTS.batterySizes.Add("dodo", 550f);
            CONSTANTS.batterySizes.Add("marshall", 60f);
            CONSTANTS.batterySizes.Add("blimp2", 300f);
            CONSTANTS.batterySizes.Add("gauntlet2", 70f);
            CONSTANTS.batterySizes.Add("stalion", 70f);
            CONSTANTS.batterySizes.Add("stalion2", 70f);
            CONSTANTS.batterySizes.Add("blista2", 50f);
            CONSTANTS.batterySizes.Add("blista3", 50f);
            CONSTANTS.batterySizes.Add("sanchez01", (float)num);
            CONSTANTS.batterySizes.Add("sanchez02", (float)num);
            CONSTANTS.batterySizes.Add("carbon", (float)num);
        }

        public static void loadTextElements(string file)
        {
            CONSTANTS.textElements.Clear();
            ScriptSettings scriptSetting = ScriptSettings.Load(file);
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    string value = scriptSetting.GetValue(string.Concat("TextElement", i), "Text");
                    float single = float.Parse(scriptSetting.GetValue(string.Concat("TextElement", i), "xPos"));
                    float single1 = float.Parse(scriptSetting.GetValue(string.Concat("TextElement", i), "yPos"));
                    float single2 = float.Parse(scriptSetting.GetValue(string.Concat("TextElement", i), "fontSize"));
                    CONSTANTS.textElements.Add(new TextElement(value, single, single1, single2));
                }
                catch (Exception exception)
                {
                }
            }
        }
    }
}