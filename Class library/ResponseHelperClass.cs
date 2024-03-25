

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;







namespace ClassLibrary
{


    public class ResponseHelper
    {


        public static string JsonString { get; set; }
        public static string Symbol { get; set; }
        public static string reqType { get; set; }
        public static string Address { get; set; }
        public static string apiKey { get; set; }


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
            TargetClass ReturnObject = default(TargetClass);
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


























