using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary // polymorphic classes would help but don't have the knowledge yet
{
    
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
    public class BalanceSheetResponse
    {
        HttpClient httpClient = HttpClientProvider.GetHttpClient();


        [JsonProperty("symbol")]
        public string symbol { get; set; }

        [JsonProperty("annualReports")]
        public List<bs_AnnualReport> bs_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<bs_QuarterlyReport> bs_quarterlyReports { get; set; }



        public async Task SättaVärde(string symbol, string apikey, bool demo)

        {


            string fullAdress = $"https://www.alphavantage.co/query?function=Balance_sheet&symbol={symbol}&apikey={apikey}";
            if (demo == true)
            {

                fullAdress = "https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol=IBM&apikey=demo";

            }



            HttpResponseMessage response = await httpClient.GetAsync(fullAdress);


            string responseBody = await response.Content.ReadAsStringAsync();
            try
            {


                BalanceSheetResponse balanceSheet = JsonConvert.DeserializeObject<BalanceSheetResponse>(responseBody);


                bs_quarterlyReports = balanceSheet.bs_quarterlyReports;

                bs_annualReports = balanceSheet.bs_annualReports;





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


    }

    public class GlobalMarketResponse //market open/close status
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("markets")]
        public List<MarketData> Markets { get; set; }

        public async Task SättaVärde(string symbol, string apikey, bool demo)

        {
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            string fullAdress = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={symbol}&apikey={apikey}";
            if (demo == true)
            {

                fullAdress = "https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol=IBM&apikey=demo";

            }


            HttpResponseMessage response = await httpClient.GetAsync(fullAdress);


            string responseBody = await response.Content.ReadAsStringAsync();
            try
            {


                GlobalMarketResponse marketResponse = JsonConvert.DeserializeObject<GlobalMarketResponse>(responseBody);


                Markets = marketResponse.Markets;




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


    }

    public class GlobalQuoteResponse // quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }

        public async Task SättaVärde(string symbol, string apikey, bool demo)

        {
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            string fullAdress = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apikey}";
            if (demo == true)
            {

                fullAdress = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo";

            }
            HttpResponseMessage response = await httpClient.GetAsync(fullAdress);


            string responseBody = await response.Content.ReadAsStringAsync();
            try
            {

                GlobalQuoteResponse Globalquote = JsonConvert.DeserializeObject<GlobalQuoteResponse>(responseBody);


                GlobalQuote = Globalquote.GlobalQuote;

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

    }
    public class TickerSearchResponse
    {

        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }
        public async Task SättaVärde(string symbol, string apikey, bool demo)

        {
            HttpClient httpClient = HttpClientProvider.GetHttpClient();

            string fullAdress = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={symbol}&apikey={apikey}";
            if (demo == true)
            {

                fullAdress = "https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=tesco&apikey=demo";

            }

            HttpResponseMessage response = await httpClient.GetAsync(fullAdress);


            string responseBody = await response.Content.ReadAsStringAsync();
            if( responseBody == "")
            {
                MessageBox.Show("RATE LIMIT");
            }
            try
            {

                TickerSearchResponse TickerSearch = JsonConvert.DeserializeObject<TickerSearchResponse>(responseBody);


                bestMatches = TickerSearch.bestMatches;

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


    }

    public class IncomeStatementResponse // income_statement
    {
        [JsonProperty("symbol")]
        public string symbol_ { get; set; }
        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
        public bool success { get; set; }



        public async Task SättaVärde(string symbol, string apikey, bool demo)

        {
            HttpClient httpClient = new HttpClient();

            string fullAdress = $"https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol={symbol}&apikey={apikey}";
            if (demo == true)
            {

                fullAdress = "https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol=IBM&apikey=demo";

            }

            HttpResponseMessage response = await httpClient.GetAsync(fullAdress);


            string responseBody = await response.Content.ReadAsStringAsync();
            try
            {


                IncomeStatementResponse incomestatement = JsonConvert.DeserializeObject<IncomeStatementResponse>(responseBody);
                success = true;
                
                ic_annualReports = incomestatement.ic_annualReports;
                ic_quarterlyReports = incomestatement.ic_quarterlyReports;
                symbol_ = incomestatement.symbol_;

                // för testing

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Request Exception: {ex.Message}");
                success = false;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"JSON Deserialization Exception: {ex.Message}");
                success = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
                success = false;
            }
            
        }


    }


    public class OverviewResponse
    {

        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CIK { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string FiscalYearEnd { get; set; }
        public string LatestQuarter { get; set; }
        public string MarketCapitalization { get; set; }
        public string EBITDA { get; set; }
        public string PERatio { get; set; }
        public string PEGRatio { get; set; }
        public string BookValue { get; set; }
        public string DividendPerShare { get; set; }

        public string DividendYield { get; set; }

        public string EPS { get; set; }

        public string RevenuePerShareTTM { get; set; }

        public string ProfitMargin { get; set; }

        public string OperatingMarginTTM { get; set; }

        public string ReturnOnAssetsTTM { get; set; }

        public string ReturnOnEquityTTM { get; set; }

        public string RevenueTTM { get; set; }

        public string GrossProfitTTM { get; set; }

        public string DilutedEPSTTM { get; set; }

        public string QuarterlyEarningsGrowthYOY { get; set; }

        public string QuarterlyRevenueGrowthYOY { get; set; }
        public string AnalystTargetPrice { get; set; }
        public string TrailingPE { get; set; }
        public string ForwardPE { get; set; }
        public string PriceToSalesRatioTTM { get; set; }
        public string PriceToBookRatio { get; set; }
        public string EVToRevenue { get; set; }
        public string EVToEBITDA { get; set; }
        public string Beta { get; set; }

        [JsonProperty("52WeekHigh")]
        public string _52WeekHigh { get; set; }
        [JsonProperty("52WeekLow")]
        public string _52WeekLow { get; set; }
        [JsonProperty("50DayMovingAverage")]
        public string _50DayMovingAverage { get; set; }
        [JsonProperty("200DayMovingAverage")]
        public string _200DayMovingAverage { get; set; }
        public string SharesOutstanding { get; set; }
        public string DividendDate { get; set; }
        public string ExDividendDate { get; set; }



    }





    public class GlobalQuote // quote endpoint/global quote
    {
        [JsonProperty("01. symbol")]
        public string _01symbol { get; set; }

        [JsonProperty("02. open")]
        public string _02open { get; set; }

        [JsonProperty("03. high")]
        public string _03high { get; set; }

        [JsonProperty("04. low")]
        public string _04low { get; set; }

        [JsonProperty("05. price")]
        public string _05price { get; set; }

        [JsonProperty("06. volume")]
        public string _06volume { get; set; }

        [JsonProperty("07. latest trading day")]
        public string _07latesttradingday { get; set; }

        [JsonProperty("08. previous close")]
        public string _08previousclose { get; set; }

        [JsonProperty("09. change")]
        public string _09change { get; set; }

        [JsonProperty("10. change percent")]
        public string _10changepercent { get; set; }


    }

    public class BestMatch
    {
        [JsonProperty("1. symbol")]
        public string symbol { get; set; }

        [JsonProperty("2. name")]
        public string name { get; set; }

        [JsonProperty("3. type")]
        public string type { get; set; }

        [JsonProperty("4. region")]
        public string region { get; set; }

        [JsonProperty("5. marketOpen")]
        public string marketOpen { get; set; }

        [JsonProperty("6. marketClose")]
        public string marketClose { get; set; }

        [JsonProperty("7. timezone")]
        public string timezone { get; set; }

        [JsonProperty("8. currency")]
        public string currency { get; set; }

        [JsonProperty("9. matchScore")]
        public string matchScore { get; set; }
    }








    // Define a class to represent the JSON response

    public class MarketData    //market open/close status
    {
        [JsonProperty("market_type")]
        public string market_type { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("primary_exchanges")]
        public string primary_exchanges { get; set; }

        [JsonProperty("local_open")]
        public string local_open { get; set; }

        [JsonProperty("local_close")]
        public string local_close { get; set; }

        [JsonProperty("current_status")]
        public string current_status { get; set; }

        [JsonProperty("notes")]
        public string notes { get; set; }
    }






    public class ic_Annualreport
    {
        [JsonProperty("fiscalDateEnding")]
        public string fiscalDateEnding { get; set; }

        [JsonProperty("reportedCurrency")]
        public string reportedCurrency { get; set; }

        [JsonProperty("grossProfit")]
        public string grossProfit { get; set; }

        [JsonProperty("totalRevenue")]
        public string totalRevenue { get; set; }

        [JsonProperty("costOfRevenue")]
        public string costOfRevenue { get; set; }

        [JsonProperty("costofGoodsAndServicesSold")]
        public string costofGoodsAndServicesSold { get; set; }

        [JsonProperty("operatingIncome")]
        public string operatingIncome { get; set; }

        [JsonProperty("sellingGeneralAndAdministrative")]
        public string sellingGeneralAndAdministrative { get; set; }

        [JsonProperty("researchAndDevelopment")]
        public string researchAndDevelopment { get; set; }

        [JsonProperty("operatingExpenses")]
        public string operatingExpenses { get; set; }

        [JsonProperty("investmentIncomeNet")]
        public string investmentIncomeNet { get; set; }

        [JsonProperty("netInterestIncome")]
        public string netInterestIncome { get; set; }

        [JsonProperty("interestIncome")]
        public string interestIncome { get; set; }

        [JsonProperty("interestExpense")]
        public string interestExpense { get; set; }

        [JsonProperty("nonInterestIncome")]
        public string nonInterestIncome { get; set; }

        [JsonProperty("otherNonOperatingIncome")]
        public string otherNonOperatingIncome { get; set; }

        [JsonProperty("depreciation")]
        public string depreciation { get; set; }

        [JsonProperty("depreciationAndAmortization")]
        public string depreciationAndAmortization { get; set; }

        [JsonProperty("incomeBeforeTax")]
        public string incomeBeforeTax { get; set; }

        [JsonProperty("incomeTaxExpense")]
        public string incomeTaxExpense { get; set; }

        [JsonProperty("interestAndDebtExpense")]
        public string interestAndDebtExpense { get; set; }

        [JsonProperty("netIncomeFromContinuingOperations")]
        public string netIncomeFromContinuingOperations { get; set; }

        [JsonProperty("comprehensiveIncomeNetOfTax")]
        public string comprehensiveIncomeNetOfTax { get; set; }

        [JsonProperty("ebit")]
        public string ebit { get; set; }

        [JsonProperty("ebitda")]
        public string ebitda { get; set; }

        [JsonProperty("netIncome")]
        public string netIncome { get; set; }

        public static implicit operator List<object>(ic_Annualreport v)
        {
            throw new NotImplementedException();
        }
    }

    public class ic_Quarterlyreport //income statement - quarterly
    {
        [JsonProperty("fiscalDateEnding")]
        public string fiscalDateEnding { get; set; }

        [JsonProperty("reportedCurrency")]
        public string reportedCurrency { get; set; }

        [JsonProperty("grossProfit")]
        public string grossProfit { get; set; }

        [JsonProperty("totalRevenue")]
        public string totalRevenue { get; set; }

        [JsonProperty("costOfRevenue")]
        public string costOfRevenue { get; set; }

        [JsonProperty("costofGoodsAndServicesSold")]
        public string costofGoodsAndServicesSold { get; set; }

        [JsonProperty("operatingIncome")]
        public string operatingIncome { get; set; }

        [JsonProperty("sellingGeneralAndAdministrative")]
        public string sellingGeneralAndAdministrative { get; set; }

        [JsonProperty("researchAndDevelopment")]
        public string researchAndDevelopment { get; set; }

        [JsonProperty("operatingExpenses")]
        public string operatingExpenses { get; set; }

        [JsonProperty("investmentIncomeNet")]
        public string investmentIncomeNet { get; set; }

        [JsonProperty("netInterestIncome")]
        public string netInterestIncome { get; set; }

        [JsonProperty("interestIncome")]
        public string interestIncome { get; set; }

        [JsonProperty("interestExpense")]
        public string interestExpense { get; set; }

        [JsonProperty("nonInterestIncome")]
        public string nonInterestIncome { get; set; }

        [JsonProperty("otherNonOperatingIncome")]
        public string otherNonOperatingIncome { get; set; }

        [JsonProperty("depreciation")]
        public string depreciation { get; set; }

        [JsonProperty("depreciationAndAmortization")]
        public string depreciationAndAmortization { get; set; }

        [JsonProperty("incomeBeforeTax")]
        public string incomeBeforeTax { get; set; }

        [JsonProperty("incomeTaxExpense")]
        public string incomeTaxExpense { get; set; }

        [JsonProperty("interestAndDebtExpense")]
        public string interestAndDebtExpense { get; set; }

        [JsonProperty("netIncomeFromContinuingOperations")]
        public string netIncomeFromContinuingOperations { get; set; }

        [JsonProperty("comprehensiveIncomeNetOfTax")]
        public string comprehensiveIncomeNetOfTax { get; set; }

        [JsonProperty("ebit")]
        public string ebit { get; set; }

        [JsonProperty("ebitda")]
        public string ebitda { get; set; }

        [JsonProperty("netIncome")]
        public string netIncome { get; set; }


    }


    public class bs_AnnualReport //balancesheet
    {
        [JsonProperty("fiscalDateEnding")]
        public string fiscalDateEnding { get; set; }

        [JsonProperty("reportedCurrency")]
        public string reportedCurrency { get; set; }

        [JsonProperty("totalAssets")]
        public string totalAssets { get; set; }

        [JsonProperty("totalCurrentAssets")]
        public string totalCurrentAssets { get; set; }

        [JsonProperty("cashAndCashEquivalentsAtCarryingValue")]
        public string cashAndCashEquivalentsAtCarryingValue { get; set; }

        [JsonProperty("cashAndShortTermInvestments")]
        public string cashAndShortTermInvestments { get; set; }

        [JsonProperty("inventory")]
        public string inventory { get; set; }

        [JsonProperty("currentNetReceivables")]
        public string currentNetReceivables { get; set; }

        [JsonProperty("totalNonCurrentAssets")]
        public string totalNonCurrentAssets { get; set; }

        [JsonProperty("propertyPlantEquipment")]
        public string propertyPlantEquipment { get; set; }

        [JsonProperty("accumulatedDepreciationAmortizationPPE")]
        public string accumulatedDepreciationAmortizationPPE { get; set; }

        [JsonProperty("intangibleAssets")]
        public string intangibleAssets { get; set; }

        [JsonProperty("intangibleAssetsExcludingGoodwill")]
        public string intangibleAssetsExcludingGoodwill { get; set; }

        [JsonProperty("goodwill")]
        public string goodwill { get; set; }

        [JsonProperty("investments")]
        public string investments { get; set; }

        [JsonProperty("longTermInvestments")]
        public string longTermInvestments { get; set; }

        [JsonProperty("shortTermInvestments")]
        public string shortTermInvestments { get; set; }

        [JsonProperty("otherCurrentAssets")]
        public string otherCurrentAssets { get; set; }

        [JsonProperty("otherNonCurrentAssets")]
        public string otherNonCurrentAssets { get; set; }

        [JsonProperty("totalLiabilities")]
        public string totalLiabilities { get; set; }

        [JsonProperty("totalCurrentLiabilities")]
        public string totalCurrentLiabilities { get; set; }

        [JsonProperty("currentAccountsPayable")]
        public string currentAccountsPayable { get; set; }

        [JsonProperty("deferredRevenue")]
        public string deferredRevenue { get; set; }

        [JsonProperty("currentDebt")]
        public string currentDebt { get; set; }

        [JsonProperty("shortTermDebt")]
        public string shortTermDebt { get; set; }

        [JsonProperty("totalNonCurrentLiabilities")]
        public string totalNonCurrentLiabilities { get; set; }

        [JsonProperty("capitalLeaseObligations")]
        public string capitalLeaseObligations { get; set; }

        [JsonProperty("longTermDebt")]
        public string longTermDebt { get; set; }

        [JsonProperty("currentLongTermDebt")]
        public string currentLongTermDebt { get; set; }

        [JsonProperty("longTermDebtNoncurrent")]
        public string longTermDebtNoncurrent { get; set; }

        [JsonProperty("shortLongTermDebtTotal")]
        public string shortLongTermDebtTotal { get; set; }

        [JsonProperty("otherCurrentLiabilities")]
        public string otherCurrentLiabilities { get; set; }

        [JsonProperty("otherNonCurrentLiabilities")]
        public string otherNonCurrentLiabilities { get; set; }

        [JsonProperty("totalShareholderEquity")]
        public string totalShareholderEquity { get; set; }

        [JsonProperty("treasuryStock")]
        public string treasuryStock { get; set; }

        [JsonProperty("retainedEarnings")]
        public string retainedEarnings { get; set; }

        [JsonProperty("commonStock")]
        public string commonStock { get; set; }

        [JsonProperty("commonStockSharesOutstanding")]
        public string commonStockSharesOutstanding { get; set; }
    }
}

public class bs_QuarterlyReport //balancesheet
{
    [JsonProperty("fiscalDateEnding")]
    public string fiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")]
    public string reportedCurrency { get; set; }

    [JsonProperty("totalAssets")]
    public string totalAssets { get; set; }

    [JsonProperty("totalCurrentAssets")]
    public string totalCurrentAssets { get; set; }

    [JsonProperty("cashAndCashEquivalentsAtCarryingValue")]
    public string cashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonProperty("cashAndShortTermInvestments")]
    public string cashAndShortTermInvestments { get; set; }

    [JsonProperty("inventory")]
    public string inventory { get; set; }

    [JsonProperty("currentNetReceivables")]
    public string currentNetReceivables { get; set; }

    [JsonProperty("totalNonCurrentAssets")]
    public string totalNonCurrentAssets { get; set; }

    [JsonProperty("propertyPlantEquipment")]
    public string propertyPlantEquipment { get; set; }

    [JsonProperty("accumulatedDepreciationAmortizationPPE")]
    public string accumulatedDepreciationAmortizationPPE { get; set; }

    [JsonProperty("intangibleAssets")]
    public string intangibleAssets { get; set; }

    [JsonProperty("intangibleAssetsExcludingGoodwill")]
    public string intangibleAssetsExcludingGoodwill { get; set; }

    [JsonProperty("goodwill")]
    public string goodwill { get; set; }

    [JsonProperty("investments")]
    public string investments { get; set; }

    [JsonProperty("longTermInvestments")]
    public string longTermInvestments { get; set; }

    [JsonProperty("shortTermInvestments")]
    public string shortTermInvestments { get; set; }

    [JsonProperty("otherCurrentAssets")]
    public string otherCurrentAssets { get; set; }

    [JsonProperty("otherNonCurrentAssets")]
    public string otherNonCurrentAssets { get; set; }

    [JsonProperty("totalLiabilities")]
    public string totalLiabilities { get; set; }

    [JsonProperty("totalCurrentLiabilities")]
    public string totalCurrentLiabilities { get; set; }

    [JsonProperty("currentAccountsPayable")]
    public string currentAccountsPayable { get; set; }

    [JsonProperty("deferredRevenue")]
    public string deferredRevenue { get; set; }

    [JsonProperty("currentDebt")]
    public string currentDebt { get; set; }

    [JsonProperty("shortTermDebt")]
    public string shortTermDebt { get; set; }

    [JsonProperty("totalNonCurrentLiabilities")]
    public string totalNonCurrentLiabilities { get; set; }

    [JsonProperty("capitalLeaseObligations")]
    public string capitalLeaseObligations { get; set; }

    [JsonProperty("longTermDebt")]
    public string longTermDebt { get; set; }

    [JsonProperty("currentLongTermDebt")]
    public string currentLongTermDebt { get; set; }

    [JsonProperty("longTermDebtNoncurrent")]
    public string longTermDebtNoncurrent { get; set; }

    [JsonProperty("shortLongTermDebtTotal")]
    public string shortLongTermDebtTotal { get; set; }

    [JsonProperty("otherCurrentLiabilities")]
    public string otherCurrentLiabilities { get; set; }

    [JsonProperty("otherNonCurrentLiabilities")]
    public string otherNonCurrentLiabilities { get; set; }

    [JsonProperty("totalShareholderEquity")]
    public string totalShareholderEquity { get; set; }

    [JsonProperty("treasuryStock")]
    public string treasuryStock { get; set; }

    [JsonProperty("retainedEarnings")]
    public string retainedEarnings { get; set; }

    [JsonProperty("commonStock")]
    public string commonStock { get; set; }

    [JsonProperty("commonStockSharesOutstanding")]
    public string commonStockSharesOutstanding { get; set; }
}






