

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.RichTextBox;






namespace ClassLibrary
{
    public class SetValue
    {


      
        
        
     
        private static bool Saved { get; set; }


        public static void SetObject<TargetClass>(TargetClass TargetObject, string jsonString)
        {

            try
            {
                TargetObject = JsonConvert.DeserializeObject<TargetClass>(jsonString);

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Request Exception: {ex.Message}");
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                MessageBox.Show($"JSON Deserialization Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
        
            public async static Task<bool> Validate(string prekey) // validates key with incomeStatement request.
            {
                //  Note that any non-key related issues will still result in no validation

                IncomeStatementResponse income = new IncomeStatementResponse(prekey, "Income_Statement", "IBM");

                IncomeStatementResponse demoIncome = new IncomeStatementResponse("DEMO", "Income_Statement", "IBM");
                await income.SetJsonString();
                await demoIncome.SetJsonString();
           
            SetValue.SetObject( income,income.JsonString); //during this call a new instance of IncomeStatementResponse is created for some reason? i.e malfunctions
                SetValue.SetObject( demoIncome,demoIncome.JsonString);// 


                string temp = null;
                string temp2 = null;//does not really matter what the strings are at first.
                try
                {
                    temp = income.ic_annualReports[0].totalRevenue;
                    temp2 = demoIncome.ic_annualReports[0].totalRevenue;
                }
                catch
                {
                    return false;
                }
                if (temp == temp2 && temp != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }



        }


        public class AdressClass //TODO
    {
        public static string Base { get; set; }
        public static string ApiKey { get; set; }
        public static string Function { get; set; }

    }


    public static class HttpClientProvider
    {
        // HttpClient instance
        private static readonly HttpClient httpClient = new HttpClient();

        // Global HttpClient Instance
        public static HttpClient GetHttpClient()
        {
            return httpClient;
        }
        // Disposing here:
        public static void DisposeHttpClient()
        {
            httpClient.Dispose();
        }



    }
}



















    






