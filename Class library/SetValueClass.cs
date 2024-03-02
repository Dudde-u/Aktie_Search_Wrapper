

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


        //method returns an object enabling it to be async
        public static async Task<TargetClass> SetObjectAsync<TargetClass>(TargetClass target, string Address)
        {
         
            

            //Gets the JSON data 
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(Address);

            string JsonString = await response.Content.ReadAsStringAsync();


            //Deserealization of said JSON data
            TargetClass ReturnObject =  default(TargetClass);
            try
            {
                ReturnObject = await Task.Run(() => JsonConvert.DeserializeObject<TargetClass>(JsonString));

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
              
            
            return ReturnObject;
        }
        
            public async static Task<bool> ValidateAsync(string prekey) // validates key with incomeStatement request.
            {
            //  Note that any non-key related issues will still result in no validation

            GlobalQuoteResponse GQ = new GlobalQuoteResponse(prekey, "Global_Quote", "IBM");
            await GQ.Initialize(); //Fix Async behaviour here
            GlobalQuoteResponse demoGQ = new GlobalQuoteResponse("demo", "Global_Quote", "IBM");
            await demoGQ.Initialize(); //Fix Async behaviour here

            GQ =await SetValue.SetObjectAsync<GlobalQuoteResponse>(GQ, GQ.Address);
            demoGQ = await SetValue.SetObjectAsync<GlobalQuoteResponse>(demoGQ, demoGQ.Address); 
            //object.Completion not necessary here

            string temp = null;
                string temp2 = null;//does not really matter what the strings are assigned at first.
                try
                {
                temp = GQ.GlobalQuote._06volume;
                    temp2 = demoGQ.GlobalQuote._06volume;
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



















    






