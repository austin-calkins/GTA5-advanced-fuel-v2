using System;
using System.IO;

namespace Advanced_Fuel_Mod_v2
{
    internal class LOG
    {
        public static string file;

        static LOG()
        {
            LOG.file = "Scripts/AdvancedFuelMod_ErrorLog.txt";
        }

        public LOG()
        {
        }

        public static void write(string text)
        {
            if (!File.Exists(LOG.file))
            {
                File.Create(LOG.file);
                LOG.write(text);
            }
            else
            {
                DateTime now = DateTime.Now;
                string str = string.Concat("[", now.ToShortTimeString(), "] ", text);
                FileStream fileStream = new FileStream(LOG.file, FileMode.Append);
                byte[] numArray = new byte[str.Length * 2];
                Buffer.BlockCopy(str.ToCharArray(), 0, numArray, 0, (int)numArray.Length);
                fileStream.Write(numArray, 0, (int)numArray.Length);
                fileStream.Flush();
                fileStream.Close();
            }
        }
    }
}