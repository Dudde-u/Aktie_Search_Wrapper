using Class_library;
using ClassLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
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
        private static string Symbol {
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
        
        private static string Apikey {
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
            //switch måste fixas, ytterligare går det säkert att göra på ett mer effektivt sätt
            //og = switch(target.ToString())
            switch ("IncomeStatement")
            {
                case "TickerSearch":
                    Address = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={Symbol}&apikey={Apikey}";
                    break;
                case "GlobalQuote":
                    Address = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "IncomeStatement":
                    Address = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={Symbol}&apikey={Apikey}";
                    break;
                case "BalanceSheet":
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
        public static async Task Prepare<TargetClass>(TargetClass TargetObject,string symbol,string apikey)
        {
            Symbol = symbol;
            Apikey = apikey;

            await AddressSet(TargetObject);
            
           await SetJsonString();
        
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
    public class BalanceSheetResponse : Responses
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

    public class GlobalQuoteResponse : Responses // quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }

       public string Symbol { get; set; }

    }
    public class TickerSearchResponse
    {

        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }
       

    }

    public class IncomeStatementResponse : Responses // income_statement
{
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }

    }







