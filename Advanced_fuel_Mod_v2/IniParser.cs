using System;
using System.Collections;
using System.IO;

namespace Advanced_Fuel_Mod_v2
{
    public class IniParser
    {
        private Hashtable keyPairs = new Hashtable();

        private string iniFilePath;

        public IniParser(string iniPath)
        {
            IniParser.SectionPair sectionPair = new IniParser.SectionPair();
            TextReader streamReader = null;
            string i = null;
            string str = null;
            string[] strArrays = null;
            this.iniFilePath = iniPath;
            if (!File.Exists(iniPath))
            {
                throw new FileNotFoundException(string.Concat("Unable to locate ", iniPath));
            }
            try
            {
                try
                {
                    streamReader = new StreamReader(iniPath);
                    for (i = streamReader.ReadLine(); i != null; i = streamReader.ReadLine())
                    {
                        i = i.Trim();
                        if (i != "")
                        {
                            if ((!i.StartsWith("[") ? true : !i.EndsWith("]")))
                            {
                                char[] chrArray = new char[] { '=' };
                                strArrays = i.Split(chrArray, 2);
                                string str1 = null;
                                if (str == null)
                                {
                                    str = "ROOT";
                                }
                                sectionPair.Section = str;
                                sectionPair.Key = strArrays[0];
                                if ((int)strArrays.Length > 1)
                                {
                                    str1 = strArrays[1];
                                }
                                this.keyPairs.Add(sectionPair, str1);
                            }
                            else
                            {
                                str = i.Substring(1, i.Length - 2);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }

        public void AddSetting(string sectionName, string settingName, string settingValue)
        {
            IniParser.SectionPair sectionPair = new IniParser.SectionPair();
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;
            if (this.keyPairs.ContainsKey(sectionPair))
            {
                this.keyPairs.Remove(sectionPair);
            }
            this.keyPairs.Add(sectionPair, settingValue);
        }

        public void AddSetting(string sectionName, string settingName)
        {
            this.AddSetting(sectionName, settingName, null);
        }

        public void DeleteSetting(string sectionName, string settingName)
        {
            IniParser.SectionPair sectionPair = new IniParser.SectionPair();
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;
            if (this.keyPairs.ContainsKey(sectionPair))
            {
                this.keyPairs.Remove(sectionPair);
            }
        }

        public string[] EnumSection(string sectionName)
        {
            ArrayList arrayLists = new ArrayList();
            foreach (IniParser.SectionPair key in this.keyPairs.Keys)
            {
                if (key.Section == sectionName)
                {
                    arrayLists.Add(key.Key);
                }
            }
            return (string[])arrayLists.ToArray(typeof(string));
        }

        public string GetSetting(string sectionName, string settingName)
        {
            IniParser.SectionPair sectionPair = new IniParser.SectionPair();
            sectionPair.Section = sectionName;
            sectionPair.Key = settingName;
            return (string)this.keyPairs[sectionPair];
        }

        public void SaveSettings(string newFilePath)
        {
            IniParser.SectionPair key = new IniParser.SectionPair();
            ArrayList arrayLists = new ArrayList();
            string item = "";
            string str = "";
            foreach (IniParser.SectionPair key in this.keyPairs.Keys)
            {
                if (!arrayLists.Contains(key.Section))
                {
                    arrayLists.Add(key.Section);
                }
            }
            foreach (string arrayList in arrayLists)
            {
                str = string.Concat(str, "[", arrayList, "]\r\n");
                foreach (IniParser.SectionPair sectionPair in this.keyPairs.Keys)
                {
                    if (sectionPair.Section == arrayList)
                    {
                        item = (string)this.keyPairs[sectionPair];
                        if (item != null)
                        {
                            item = string.Concat("=", item);
                        }
                        str = string.Concat(str, sectionPair.Key, item, "\r\n");
                    }
                }
                str = string.Concat(str, "\r\n");
            }
            try
            {
                TextWriter streamWriter = new StreamWriter(newFilePath);
                streamWriter.Write(str);
                streamWriter.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void SaveSettings()
        {
            this.SaveSettings(this.iniFilePath);
        }

        private struct SectionPair
        {
            public string Section;

            public string Key;
        }
    }
}