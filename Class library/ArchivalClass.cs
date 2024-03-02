using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_library
{

    public static class Archival //TODO
    {
        public static bool InitTest(string requestType, string symbol)
        {
            string path = ""; // figure out relative filepath
            string options = "";
            path = requestType + symbol + options + ".JSON";
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
        public static void SaveToFile(string JSONstring, string symbol,string RequstType)
        {
            DateTime dateTime = DateTime.Now;
            string filepath = "Save" + symbol +dateTime.Month+ RequstType + ".txt";
            File.WriteAllText(filepath, JSONstring);
            StreamWriter writer = File.AppendText(filepath);
            writer.Write(filepath+"   ");


            File.WriteAllText(filepath, JSONstring);
           

         
        }
        public async static void ReadFromFile(string requestType, string symbol)
        {
            //file naming convention needed, I.e how are files named
            //TODO
            string options = "";
            DateTime date = DateTime.Now;
            string path = requestType + symbol + options + ".txt";
            StreamReader StreamReader = new StreamReader(path);
        }

    }

}
