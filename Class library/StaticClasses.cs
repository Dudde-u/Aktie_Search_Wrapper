

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
                    MessageBox.Show("symbol is null");
                    throw new Exception();
                }
            }
            set { jsonString = value; }
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

        public static Task AddressSet<TargetObject>(TargetObject target)
        {
            // TODO - proper structure

            switch (target.ToString())
            {
                case "TickerSearchResponse":
                    Address = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={Symbol}&apikey={Apikey}";
                    break;
                case "GlobalQuoteResponse":
                    Address = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "IncomeStatementResponse":
                    Address = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "BalanceSheetResponse":
                    Address = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={Symbol}&apikey={Apikey}";
                    break;
                default:
                case "OverviewResponse":
                    Address = $"https://www.alphavantage.co/query?function=Overview&symbol={Symbol}&apikey={Apikey}";
                    break;
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


        public static void SetObjectValue<TargetClass>(ref TargetClass TargetObject)
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
        public static async Task Prepare<TargetClass>(TargetClass TargetObject, string symbol, string apikey)
        {
            Symbol = symbol;
            Apikey = apikey;

            await AddressSet(TargetObject);

            await SetJsonString();

        }
        public async static Task<bool> Validate(string apikey) // validates key with incomeStatement API request.
        {
            // Note that any non-key related issues will still result in no validation

            IncomeStatementResponse income = new IncomeStatementResponse();

            IncomeStatementResponse demoIncome = new IncomeStatementResponse();

            await Prepare(income, "IBM", apikey);
            SetObjectValue(ref income);

            await Prepare(demoIncome, "IBM", "DEMO");
            SetObjectValue(ref demoIncome);
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
    public static class Archival
    {
        public static void InitTest(string symbol, DateTime date)
        {

        }
        public static void SaveToFile(string symbol, DateTime date)
        {

        }
        public async static void ReadFromFile<TargetClass>(TargetClass TargetObject, string symbol)
        {
            //file naming convention needed, I.e how are files named
            string options = "";
            string path = TargetObject.ToString() + symbol + options + ".txt";
            StreamReader StreamReader = new StreamReader(path);

            Char[] buffer;

            buffer = new Char[(int)StreamReader.BaseStream.Length];
            await StreamReader.ReadAsync(buffer, 0, (int)StreamReader.BaseStream.Length);
            await SetValue.Prepare(TargetObject, symbol, ""); //put apikey
            SetValue.SetObjectValue(ref TargetObject);


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





