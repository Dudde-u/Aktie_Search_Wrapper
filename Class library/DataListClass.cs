
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary // file for seeing the different types of responses
{
    public class SymbolResponse : BaseResponse
    {
    
        protected string Symbol { get; set; }
   

        public SymbolResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType) 
        {
            Symbol = symbol;
            SetAddress();
        }
        protected override void SetAddress()
        {
            switch (reqType)
            {
                case "Ticker_Search":
                    Address = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={Symbol}&apikey={apiKey}";
                    break;
                case "Global_Quote":
                    Address = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={Symbol}&apikey={apiKey}";
                    break;
                case "Income_Statement":
                    Address = "https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol="+Symbol+"&apikey="+apiKey;
                    break;
                case "Balance_Sheet":
                    Address = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={Symbol}&apikey={apiKey}";
                    break;
                case "Overview":
                    Address = $"https://www.alphavantage.co/query?function=Overview&symbol={Symbol}&apikey={apiKey}";
                    break;

                case "Cash_Flow":
                    Address = $"https://www.alphavantage.co/query?function=CASH_FLOW&symbol={Symbol}&apikey={apiKey}";
                    
                    break;
                default:
                    MessageBox.Show("TargetObject not valid");
                    throw new Exception();
            }
        }
       
    }
    public class BaseResponse
    {
        
        protected string apiKey { get; set; }
        protected string Address { get; set; }
        public string JsonString { get;  set; }
        protected string reqType { get; set; }
      
      
        public BaseResponse(string apiKey2, string reqType2)
        {

            apiKey = apiKey2;
           
            reqType = reqType2;
            SetAddress();



        }

        public async Task SetJsonString()
        {
            //check if data is saved
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(Address);

            JsonString = await response.Content.ReadAsStringAsync();
            
        }
        protected virtual void SetAddress()
        {
             switch (reqType) // more to be added
            {
                case "LosersGainers":
                    Address = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={apiKey}";

                    break;


                default:
                    MessageBox.Show("TargetObject not valid");
                    throw new Exception();

                

            }
          
        }
       
        
    }
    public class BalanceSheetResponse : SymbolResponse  // balance_sheet
    {

       

        [JsonProperty("annualReports")]
        public List<bs_AnnualReport> bs_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<bs_QuarterlyReport> bs_quarterlyReports { get; set; }
        public BalanceSheetResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType,symbol) { }
            
         

    }

    public class GlobalMarketResponse  //market open/close status
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("markets")]
        public List<MarketData> Markets { get; set; }


    }

    public class GlobalQuoteResponse : SymbolResponse// quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }

        public GlobalQuoteResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }


    }
    public class TickerSearchResponse : BaseResponse
    {

        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }

        public TickerSearchResponse(string apikey, string reqType) : base(apikey, reqType) { }
    }

    public class IncomeStatementResponse : SymbolResponse // income_statement
    {
    
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }
        public IncomeStatementResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }

    }

    public class CashFlowResponse : SymbolResponse// CashFlow
    {


        [JsonProperty("annualReports")]
        public List<CF_AnnualReport> CF_annualReports { get; set; }

        [JsonProperty("quarterlyReports")]
        public List<CF_QuarterlyReport> CF_quarterlyReports { get; set; }
        public CashFlowResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }

    }
    public class TopLosersGainersResponse : BaseResponse // LosersGainers
    {
        [JsonProperty("metadata")]
        public string metadata { get; set; }

        [JsonProperty("last_updated")]
        public string last_updated { get; set; }

        [JsonProperty("top_gainers")]
        public List<TopGainer> top_gainers { get; set; }

        [JsonProperty("top_losers")]
        public List<TopLoser> top_losers { get; set; }

        [JsonProperty("most_actively_traded")]
        public List<MostActivelyTraded> most_actively_traded { get; set; }
        public TopLosersGainersResponse(string apikey, string reqType):base(apikey, reqType) { }
    }


}
