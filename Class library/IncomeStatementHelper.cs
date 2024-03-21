using System;
using System.Collections.Generic;
using Label = System.Windows.Forms.Label;


namespace Class_library
{
    public static class IncomeStatementHelper
    {
        public static void BubbleSortLabels(ref List<Label> lista) //Label sorting based on the labels number
        {
            Label temp;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < lista.Count - (1 + i); j++)
                {
                    if ((int.Parse(lista[j].Name.Substring(5))) > (int.Parse(lista[j + 1].Name.Substring(5))))
                    {
                        temp = lista[j + 1];
                        lista[j + 1] = lista[j];
                        lista[j] = temp;
                    }
                }
            }
        }
        public static void MergeAndShowLists(List<string> dataList, List<string> multiplierList, List<Label> labellist)
        {
            for (int i = 0; i < labellist.Count; i++)
            {
                labellist[i].Text += dataList[i] + " " + multiplierList[i];
            }
        }
        public static List<string> CompareStatements(List<string> oldList, List<string> NewList) // list has to be ordered
        {
            List<string> dataOut = new List<string>();

            if (oldList.Count != NewList.Count) //
            {
                throw new Exception(message: "List count does not match");
            }
            double multiplier;
            for (int i = 0; i < oldList.Count; i++) // could be either old or new list
            {
                try //really careful here to handle all outlier data, as "outliers" are quite frequent in the data
                {
                    string oldValueString = oldList[i];
                    string newValueString = NewList[i];

                    double oldValue;
                    double newValue;

                    bool value1_ok;
                    bool value2_ok;

                    value1_ok = Double.TryParse(oldList[i], out oldValue);
                    value2_ok = Double.TryParse(NewList[i], out newValue);
                    if (oldValueString == "None")
                    {
                        oldValue = 0;
                    }
                    if (newValueString == "None")
                    {
                        newValue = 0;
                    }

                    if (oldValue == 0) //can be condensed
                    {
                        if (newValue > 0)
                        {
                            multiplier = 100;
                        }
                        else if (newValue < 0)
                        {
                            multiplier = -100;
                        }
                        else
                        {
                            multiplier = 0;
                        }
                    }
                    else if (newValue == 0)
                    {
                        if (oldValue > 0)
                        {
                            multiplier = -100;
                        }
                        else
                        {
                            multiplier = 100;
                        }
                    }
                    else
                    {
                        multiplier = ((newValue - oldValue) / Math.Abs(oldValue)) * 100;
                    }
                    double outmultiplier = Math.Round(multiplier, 1);
                    string outtext = outmultiplier + "%  ";

                    if (outmultiplier > 0)
                    { outtext += "↑"; }
                    else if (outmultiplier < 0)
                    { outtext += "↓"; }
                    else
                    { outtext += "→"; }
                    dataOut.Add(outtext);
                }
                catch { }
            }

            return dataOut;
        }
    }
}
