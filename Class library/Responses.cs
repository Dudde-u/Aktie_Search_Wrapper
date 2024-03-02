﻿
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_library;
using System.Security.Policy;

namespace ClassLibrary // file for seeing the different types of responses
{
    
   
    public class BalanceSheetResponse : SymbolResponse  // balance_sheet
    {

       

        [JsonProperty("annualReports")]
        public List<bs_AnnualReport> bs_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<bs_QuarterlyReport> bs_quarterlyReports { get; set; }
        public BalanceSheetResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType,symbol) { }
        public BalanceSheetResponse() { }


    }

    public class GlobalMarketResponse : BaseResponse //market open/close status
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("markets")]
        public List<MarketData> Markets { get; set; }

        public GlobalMarketResponse() { }
        public GlobalMarketResponse(string apikey, string reqType) : base(apikey, reqType) { }

    }

    public class GlobalQuoteResponse : SymbolResponse// quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }

        public GlobalQuoteResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }

        public GlobalQuoteResponse() { }
    }
    public class TickerSearchResponse : BaseResponse
    {

        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }

        public TickerSearchResponse(string apikey, string reqType) : base(apikey, reqType) { }
        public TickerSearchResponse() { }
    }

    public class IncomeStatementResponse : SymbolResponse // income_statement
    {
    
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }
        public IncomeStatementResponse() {}
        public IncomeStatementResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }
        

    }

    public class CashFlowResponse : SymbolResponse// CashFlow
    {


        [JsonProperty("annualReports")]
        public List<CF_AnnualReport> CF_annualReports { get; set; }

        [JsonProperty("quarterlyReports")]
        public List<CF_QuarterlyReport> CF_quarterlyReports { get; set; }
        public CashFlowResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType, symbol) { }
       public CashFlowResponse() { }

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
        public TopLosersGainersResponse(string apikey, string reqType):base(apikey, reqType) {}
        public TopLosersGainersResponse():base() {}
    }


}