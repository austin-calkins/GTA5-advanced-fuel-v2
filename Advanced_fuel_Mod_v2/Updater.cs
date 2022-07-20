using System;
using System.IO;
using System.Net;

namespace Advanced_Fuel_Mod_v2
{
    internal class Updater
    {
        private static string url;

        static Updater()
        {
            Updater.url = "https://www.gta5-mods.com/scripts/advanced-fuel-mod";
        }

        public Updater()
        {
        }

        private static string getModHTML()
        {
            HttpWebResponse response = (HttpWebResponse)WebRequest.Create(Updater.url).GetResponse();
            return (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }

        public static string getNewVersion()
        {
            string modHTML = Updater.getModHTML();
            string str = "<span class=\"version\">1.3</span>";
            string str1 = modHTML.Substring(modHTML.IndexOf(str) + str.Length);
            str1 = str1.Substring(0, str1.IndexOf("</"));
            return str1.Trim();
        }
    }
}