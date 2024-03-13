

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.RichTextBox;







namespace ClassLibrary
{

    //public class ResponseHelperProperties //maybe something TODO
    //{
    //    public static string JsonString { get; set; }
    //    public static string Symbol { get; set; }
    //    public static string reqType { get; set; }
    //    public static string Address { get; set; }
    //    public static string apiKey { get; set; }
    //}
    public class ResponseHelper
    {
        
        private static bool Saved { get; set; }
        public static string JsonString { get; set; }
        public static string Symbol {  get; set; }
        public static string reqType {  get; set; }
        public static string Address {  get; set; }
        public static string apiKey {  get; set; }


        //method returns an object enabling it to be async contrary to using ref etc
        public static async Task<TargetClass> SetObjectAsync<TargetClass>(TargetClass target, string Address)
        {

            ResponseHelper.Address = Address;


            //Gets the JSON data 
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(Address);

            string JsonString = await response.Content.ReadAsStringAsync();

            ResponseHelper.JsonString = JsonString;


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

            GlobalQuoteResponse GQ = new GlobalQuoteResponse(prekey, "IBM");
            await GQ.Initialize(); //Fix Async behaviour here

            GQ = await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(GQ, GQ.Address);

            GlobalQuoteResponse demoGQ = new GlobalQuoteResponse("demo", "IBM");
            await demoGQ.Initialize(); //Fix Async behaviour here

            demoGQ = await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(demoGQ, demoGQ.Address);


            

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



















    






