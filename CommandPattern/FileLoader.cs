using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace CommandPattern
{
    public class FileLoader
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public void GetRecieverItems(String mappingItemsFileName, ref List<IReciever> Recievers)
        {
            int number=int.Parse( loadMappingItemsFromIni(mappingItemsFileName, "items","number"));
            for(int i=0;i<number;i++)
            {
                string name= loadMappingItemsFromIni(mappingItemsFileName, "item"+(i+1).ToString(),"name");
                string script= loadMappingItemsFromIni(mappingItemsFileName, "item"+(i+1).ToString(),"script");
                IReciever reciever=new Reciever();
                reciever.Name=name;
                reciever.Script=script;
                Recievers.Add(reciever);
            }
        }
        public string loadMappingItemsFromIni(String mappingItemsFileName, String section, String Key)
        {
            int size = 255;
            int strref;
            StringBuilder retVal = new StringBuilder(255);
            String default1 = "null";
            strref = GetPrivateProfileString(section, Key, default1, retVal, size, mappingItemsFileName);
            string result = retVal.ToString();
            return result;
        }
    }
}
