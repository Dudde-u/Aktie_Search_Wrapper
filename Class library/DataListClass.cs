
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary // file for seeing the different types of responses
{
    public class BaseResponse
    {
        
    }
    public class BalanceSheetResponse  // balance_sheet
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

    public class IncomeStatementResponse // income_statement
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }

    }

    public class CashFlowResponse // CashFlow
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("annualReports")]
        public List<CF_AnnualReport> CF_annualReports { get; set; }

        [JsonProperty("quarterlyReports")]
        public List<CF_QuarterlyReport> CF_quarterlyReports { get; set; }
    }
    public class TopLosersGainersResponse // LosersGainers
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
    }


}
