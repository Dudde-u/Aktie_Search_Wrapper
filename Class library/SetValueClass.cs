

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


namespace ClassLibrary
{
    public class SetValue
    {


        private static string jsonString { get; set; }
        private static string symbol;
        private static string apiKey;
        private static string address;
        private static string requestType {  get; set; }
     
        private static bool Saved { get; set; }
        private static string JsonString
        {
            get
            {
                if (jsonString != null && jsonString != "")
                {
                    return jsonString;
                }
                else
                {
                    MessageBox.Show("Json response is null");
                    throw new Exception();
                }
            }
            set {
                if (value == null)
                {
                    MessageBox.Show("Json response is null");

                    throw new Exception();
                }
                else
                {
                    jsonString = value;
                }
            }
        }
        private static string Symbol
        {
            get
            {
                if (symbol != null && symbol != "")
                {
                    return symbol;
                }
                else
                {
                    MessageBox.Show("symbol is null");
                    throw new Exception();
                }
            }
            set { symbol = value; }
        }

        private static string Apikey
        {
            get
            {
                if (apiKey != null && apiKey != "")
                {
                    return apiKey;
                }
                else
                {
                    MessageBox.Show("ApiKey is null");
                    throw new Exception();
                }
            }
            set { apiKey = value; }
        }
        public static string Address
        {

            get
            {
                if (address != null && address != "")
                {
                    return address;
                }
                else
                {
                    MessageBox.Show("adress is null");
                    throw new Exception();
                }
            }
            set { address = value; }
        }

        public static Task SetAddress()
        {
            // TODO - proper structure

          
            switch (requestType)
            {
                case "Ticker_Search":
                    Address = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={Symbol}&apikey={Apikey}";
                    break;
                case "Global_Quote":
                    Address = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "Income_Statement":
                    Address = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "Balance_Sheet":
                    Address = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "Overview":
                    Address = $"https://www.alphavantage.co/query?function=Overview&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "LosersGainers":
                    Address = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={Apikey}";

                    break;
                case "Cash_Flow":
                    Address = $"https://www.alphavantage.co/query?function=CASH_FLOW&symbol={Symbol}&apikey={Apikey}";
                    break;
                default:
                    MessageBox.Show("TargetObject not valid");
                    throw new Exception();

                   

            }
            return Task.CompletedTask;
        }
        public static async Task SetJsonString()
        {

            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(address);

            JsonString = await response.Content.ReadAsStringAsync();
        }


        public static void SetObject<TargetClass>(ref TargetClass TargetObject)
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
        public static async Task Prepare(string requestType_, string symbol, string apikey)
        {
            Symbol = symbol;
            Apikey = apikey;

            requestType = requestType_;
            await SetAddress();
            await SetJsonString();
            //bool DataExists = Archival.InitTest(requestType, symbol);

            //if (DataExists == false) //true => data is not saved locally
            //{
            //    Saved = false;
            //    Archival.SaveToFile("","");

            //    await AddressSet();

            //    await SetJsonString();

            //}
            //else //false => data is saved locally
            //{
            //    Saved = true;
            //    Archival.ReadFromFile(requestType, symbol);
            //}
            

        }
        public async static Task<bool> Validate(string apikey) // validates key with incomeStatement API request.
        {
            // Note that any non-key related issues will still result in no validation

            IncomeStatementResponse income = new IncomeStatementResponse();

            IncomeStatementResponse demoIncome = new IncomeStatementResponse();

            await Prepare("income_statement", "IBM", apikey);
            SetObject(ref income);

            await Prepare("income_statement", "IBM", "DEMO");
            SetObject(ref demoIncome);
            string temp = null;
            string temp2 = null;
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



















    






