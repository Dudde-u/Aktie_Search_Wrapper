

using Class_library;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClassLibrary
{
    //class that helps with getting data from the API

    public class ResponseHelper 
    {


        //method returns an object enabling it to be async contrary to using ref etc
        public static async Task SetObjectAsync<TargetClass>(ISettable target)
        {
            target.IsSet = false;
            if (target is ISaveable)
            {
                ISaveable tempSaveable = (ISaveable)target;

                Archival.GetData(tempSaveable); //get archived data if it exists
            }


            try
            {

                if (target.JsonString == null) // if the data is not already stored in the object, get it from the API
                {
                    //Gets the JSON data
                    HttpClient httpClient = HttpClientProvider.GetHttpClient();

                    HttpResponseMessage response = await httpClient.GetAsync(target.Address);

                    response.EnsureSuccessStatusCode();

                    target.JsonString = await response.Content.ReadAsStringAsync();

                    
                    string exceptionstring = "Thank you for using Alpha Vantage!";
                    
                    if (target.JsonString.Contains(exceptionstring))
                    {
                        MessageBox.Show("API rate limit reached");
                        return;
                    }


                    if ((target.JsonString.Length > 40) && target is ISaveable saveable) // if data is more or less empty, don't save it
                    {
                        Archival.SaveToFile(saveable); // Save the data that has been requested
                    }

                }

                //Populate the object


                JsonConvert.PopulateObject(target.JsonString, target);

                target.IsSet = true;
            }

            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Request Exception: {ex.Message}");
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                MessageBox.Show($"JSON Deserialization Exception: {ex.Message}");
            }
            catch (Exception)
            {
                MessageBox.Show($"An unexpected error occurred");
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


























