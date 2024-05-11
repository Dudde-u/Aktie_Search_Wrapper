using ClassLibrary;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Class_library
{
    public static class ApiKeyHandler
    {
        public static string Key { get; set; }
        public static bool KeyIsValidated { get; set; }

        public async static Task<bool> ValidateAsync(string prekey) // validates key with IBM Overview request.
        {
            //  Note that any non-key related issues will still result in no validation

            try
            {
                OverviewResponse overviewResponse = new OverviewResponse(prekey,"ibm");

                HttpClient httpClient = HttpClientProvider.GetHttpClient();

                HttpResponseMessage response = await httpClient.GetAsync("https://www.alphavantage.co/query?function=OVERVIEW&symbol=IBM&apikey=" + prekey);

                response.EnsureSuccessStatusCode();

                overviewResponse.JsonString = await response.Content.ReadAsStringAsync();

                JsonConvert.PopulateObject(overviewResponse.JsonString, overviewResponse);

                string JsonString = "International Business Machines"; //should not change for the foreseeable future


                if (overviewResponse.Name == JsonString)
                {
                    KeyIsValidated = true;
                    Key = prekey;
                    return true;
                }
                else
                {
                    KeyIsValidated = false;
                    Key = prekey;
                    return false;
                }
            }
            catch { return false; }
        }
    }
}
