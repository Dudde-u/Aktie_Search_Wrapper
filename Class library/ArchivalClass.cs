using System;
using System.IO;

namespace Class_library
{
    //this file contains the code for saving and loading data locally
    public static class Archival //this could and should be done with JSON
    {
        public static void GetData(ISaveable SaveObject)
        {
            string FileIdentifier = SaveObject.FileIdentifier;
            //get the path of the DataList folder
            FileIdentifier = FileIdentifier.ToLower(); //might not be needed realistically


            string FolderPath = Path.GetFullPath("../../../DATA/SavedStockData/" + SaveObject.FolderName + "/");
            string DataListPath = FolderPath + "DataList.txt";
            string DataList = File.ReadAllText(DataListPath);

            //split the text file into an array of strings
            string[] DataListArray = DataList.Split(';');
            DateTime dateTimeStored;
            bool rewrite = false;

            //this loop will check if the data is older than deltaHours, if it is, it will empty the value
            //find the coresponding data
            for (int i = 0; i < DataListArray.Length; i++)
            {
                if (DataListArray[i].Length > 1 && DataListArray[i] != null)
                {
                    string[] temparray = DataListArray[i].Split(',');
                    if (temparray[0] == FileIdentifier)
                    {

                        dateTimeStored = DateTime.Parse(temparray[1]);
                        dateTimeStored = dateTimeStored.AddHours(SaveObject.deltaHours);
                        if (dateTimeStored > DateTime.Now.ToUniversalTime()) // if the data is older than deltaHours, empty the value
                        {
                            DataListArray[i] = "";
                                                  //rewrite of datalist file is done outside the loop for readability
                            rewrite = true;
                        }
                        break;
                    }
                }
            }
            //update the DataList file
            if (rewrite == true)
            {
                RewriteDataList(DataListArray, DataListPath);
            }
            //get the acutal data 
            try
            {
                string pathCheck = FolderPath + FileIdentifier + ".txt";
                if (rewrite && File.Exists(pathCheck) == true)
                {
                    SaveObject.JsonString = File.ReadAllText(pathCheck);
                }
                else
                {
                    SaveObject.JsonString = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                SaveObject.JsonString = null;
            }
        }
        private static void RewriteDataList(string[] oldArray, string filepath)
        {
            string writingText = "";
            string textInArray = "";
            for (int i = 0; i < oldArray.Length; i++)
            {
                textInArray = oldArray[i];
                if (textInArray != null && textInArray.Length > 1) { writingText += oldArray[i] + ";"; }

            }
            File.WriteAllText(filepath, writingText);

        }
        public static void ClearAllStockData()
        {

            string[] DirectoryArray = Directory.GetDirectories("../../../DATA/SavedStockData");
            for (int i = 0; i < DirectoryArray.Length; i++)
            {
                string[] FileArray = Directory.GetFiles(DirectoryArray[i]);
                for (int j = 0; j < FileArray.Length; j++)
                {
                    if (!FileArray[j].Contains("DataList"))
                    {
                        File.Delete(FileArray[j]);
                    }
                    else
                    {
                        File.WriteAllText(FileArray[j], "");
                    }
                }
            }

        }
        public static void SaveToFile(ISaveable SaveObject)
        {
            if (SaveObject.JsonString == null)
            {
                return;
            }
            string FileIdentifier = SaveObject.FileIdentifier.ToLower();

            string filepath = Path.GetFullPath("../../../DATA/SavedStockData/" + SaveObject.FolderName + "/");
            File.WriteAllText(filepath + FileIdentifier + ".txt", SaveObject.JsonString);
            File.AppendAllText(filepath + "DataList.txt", FileIdentifier + "," + DateTime.Now.ToUniversalTime() + ";");
        }
    }

}
