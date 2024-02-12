

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataClass;
using Class_library;

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
            // går säkert att göra på ett mer effektivt sätt

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
        public async static Task<bool> Validate(string apikey)
        {
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
    public class BalanceSheetResponse : IResponses
    {

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("annualReports")]
        public List<bs_AnnualReport> bs_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<bs_QuarterlyReport> bs_quarterlyReports { get; set; }


    }

    public class GlobalMarketResponse  //market open/close status
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("markets")]
        public List<MarketData> Markets { get; set; }


    }

    public class GlobalQuoteResponse// quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }



    }
    public class TickerSearchResponse
    {

        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }


    }

    public class IncomeStatementResponse : IResponses // income_statement
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }

    }


}





