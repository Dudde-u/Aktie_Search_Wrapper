using Class_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ClassLibrary
{

    // this file contatains all of the response classes that are used to store the data from the API

    public class BalanceSheetResponse : SymbolResponse   // balance_sheet
    {
        [JsonProperty("annualReports")]
        public List<bs_AnnualReport> bs_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<bs_QuarterlyReport> bs_quarterlyReports { get; set; }
        public BalanceSheetResponse(string apiKey, string symbol) : base(apiKey, symbol)
        {
            Address = $"https://www.alphavantage.co/query?function=BALANCE_SHEET&symbol={symbol}&apikey={apiKey}";
        }

        public override string FolderName { get { return "BalanceSheet"; } }

        public override void ensureIsSet()
        {
            try
            {
                if (bs_annualReports == null || bs_quarterlyReports == null)
                {
                    isSet = false;
                   
                }
                else
                {
                    isSet = true;

                }
               
            }
            catch (Exception) { isSet=false; }
        }
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
        public List<string> ReturnList()  //this is used to return a list of all the data that should be shown in the forms
        {
            List<string> outlist = new List<string>();

            outlist.Add(totalAssets);
            outlist.Add(totalCurrentAssets);
            outlist.Add(cashAndCashEquivalentsAtCarryingValue);
            outlist.Add(cashAndShortTermInvestments);
            outlist.Add(inventory);
            outlist.Add(currentNetReceivables);
            outlist.Add(totalNonCurrentAssets);
            outlist.Add(propertyPlantEquipment);
            outlist.Add(accumulatedDepreciationAmortizationPPE);
            outlist.Add(intangibleAssets);
            outlist.Add(intangibleAssetsExcludingGoodwill);
            outlist.Add(goodwill);
            outlist.Add(investments);
            outlist.Add(longTermInvestments);
            outlist.Add(shortTermInvestments);
            outlist.Add(otherCurrentAssets);
            outlist.Add(otherNonCurrentAssets);
            outlist.Add(totalLiabilities);
            outlist.Add(totalCurrentLiabilities);
            outlist.Add(currentAccountsPayable);
            outlist.Add(deferredRevenue);
            outlist.Add(currentDebt);
            outlist.Add(shortTermDebt);
            outlist.Add(totalNonCurrentLiabilities);
            outlist.Add(capitalLeaseObligations);
            outlist.Add(longTermDebt);
            outlist.Add(currentLongTermDebt);
            outlist.Add(longTermDebtNoncurrent);
            outlist.Add(shortLongTermDebtTotal);
            outlist.Add(otherCurrentLiabilities);
            outlist.Add(otherNonCurrentLiabilities);
            outlist.Add(totalShareholderEquity);
            outlist.Add(treasuryStock);
            outlist.Add(retainedEarnings);
            outlist.Add(commonStock);
            outlist.Add(commonStockSharesOutstanding);

            return outlist;
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

        public List<string> ReturnList() //this creates a list of all the data that should be shown in the forms
        {
            List<string> outlist = new List<string>();
            outlist.Add(totalAssets);
            outlist.Add(totalCurrentAssets);
            outlist.Add(cashAndCashEquivalentsAtCarryingValue);
            outlist.Add(cashAndShortTermInvestments);
            outlist.Add(inventory);
            outlist.Add(currentNetReceivables);
            outlist.Add(totalNonCurrentAssets);
            outlist.Add(propertyPlantEquipment);
            outlist.Add(accumulatedDepreciationAmortizationPPE);
            outlist.Add(intangibleAssets);
            outlist.Add(intangibleAssetsExcludingGoodwill);
            outlist.Add(goodwill);
            outlist.Add(investments);
            outlist.Add(longTermInvestments);
            outlist.Add(shortTermInvestments);
            outlist.Add(otherCurrentAssets);
            outlist.Add(otherNonCurrentAssets);
            outlist.Add(totalLiabilities);
            outlist.Add(totalCurrentLiabilities);
            outlist.Add(currentAccountsPayable);
            outlist.Add(deferredRevenue);
            outlist.Add(currentDebt);
            outlist.Add(shortTermDebt);
            outlist.Add(totalNonCurrentLiabilities);
            outlist.Add(capitalLeaseObligations);
            outlist.Add(longTermDebt);
            outlist.Add(currentLongTermDebt);
            outlist.Add(longTermDebtNoncurrent);
            outlist.Add(shortLongTermDebtTotal);
            outlist.Add(otherCurrentLiabilities);
            outlist.Add(otherNonCurrentLiabilities);
            outlist.Add(totalShareholderEquity);
            outlist.Add(treasuryStock);
            outlist.Add(retainedEarnings);
            outlist.Add(commonStock);
            outlist.Add(commonStockSharesOutstanding);

            return outlist;
        }
    }

    public class GlobalMarketResponse : BaseResponse //market open/close status
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("markets")]
        public List<MarketData> MarketList { get; set; }
        public override string FileIdentifier { get { return "GlobalMarket"; } }
        public override string FolderName { get { return "GlobalMarket"; } }
        public override int deltaHours { get { return 0; } }

        public GlobalMarketResponse(string apikey) : base(apikey)
        {

            Address = $"https://www.alphavantage.co/query?function=MARKET_STATUS&apikey={apikey}";
        }
        public override void ensureIsSet()
        {

            if (MarketList == null)
            {
                isSet = false;
            }
            else { isSet = true;}
        }


    }
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


    public class GlobalQuoteResponse : SymbolResponse// quote endpoint/global quote
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }

        public GlobalQuoteResponse(string apiKey, string symbol) : base(apiKey, symbol)
        {
            Address = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}";
        }


        public override string FolderName { get { return "GlobalQuote"; } }

        public override void ensureIsSet()
        {
            try
            {
                if (GlobalQuote == null)
                {
                    isSet = false;
                }
                else
                {
                    isSet = true;
                }
            }
            catch (Exception) { isSet = false; }

        }


    }
    public class GlobalQuote  // quote endpoint/global quote
    {
        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }

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


    public class TickerSearchResponse : SymbolResponse
    {


        [JsonProperty("bestMatches")]
        public List<BestMatch> bestMatches { get; set; }

        public TickerSearchResponse(string apikey, string symbol) : base(apikey, symbol)
        {
            Address = $"https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords={symbol}&apikey={apikey}";
        }
        public override string FolderName { get { return "TickerSearch"; } }
        
     
        public override void ensureIsSet()
        {

            try
            {

                if (bestMatches == null)
                {
                    isSet = false;

                }
                else
                {
                    isSet = true;
                } 
            }
            catch (Exception) { isSet = false; }
        }





    }
    public class BestMatch
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }

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



    public class IncomeStatementResponse : SymbolResponse // income_statement
    {

        [JsonProperty("annualReports")]
        public List<ic_Annualreport> ic_annualReports { get; set; }
        [JsonProperty("quarterlyReports")]
        public List<ic_Quarterlyreport> ic_quarterlyReports { get; set; }
       
        public override string FolderName { get { return "IncomeStatement"; } }
        public IncomeStatementResponse(string apiKey, string symbol) : base(apiKey, symbol)
        {

            Address = "https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol=" + symbol + "&apikey=" + apiKey;
        }

        public override void ensureIsSet()
        {
            try
            {
                if (ic_annualReports == null || ic_quarterlyReports == null)
                {
                    isSet = false;
                    return;
                }
                else
                {
                    isSet = true;
                    
                }
              
            }
            catch (Exception)
            {
                isSet = false;
            }
        }



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
        public static string[] TextArray { get; set; }
        public List<string> ReturnList()
        {
            List<string> DataList = new List<string>(); //returns a list of all the data that should be shown in the forms


            DataList.Add(grossProfit);
            DataList.Add(totalRevenue);
            DataList.Add(costOfRevenue);
            DataList.Add(costofGoodsAndServicesSold);
            DataList.Add(operatingIncome);
            DataList.Add(sellingGeneralAndAdministrative);
            DataList.Add(researchAndDevelopment);
            DataList.Add(operatingExpenses);
            DataList.Add(investmentIncomeNet);
            DataList.Add(netInterestIncome);
            DataList.Add(interestIncome);
            DataList.Add(interestExpense);
            DataList.Add(nonInterestIncome);
            DataList.Add(otherNonOperatingIncome);
            DataList.Add(depreciation);
            DataList.Add(depreciationAndAmortization);
            DataList.Add(incomeBeforeTax);
            DataList.Add(incomeTaxExpense);
            DataList.Add(interestAndDebtExpense);
            DataList.Add(netIncomeFromContinuingOperations);
            DataList.Add(comprehensiveIncomeNetOfTax);
            DataList.Add(ebit);
            DataList.Add(ebitda);
            DataList.Add(netIncome);

            return DataList;
        }
    }
    public class ic_Quarterlyreport
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

        public List<string> ReturnList() //returns a list of all the data that should be shown in the forms
        {
            List<string> DataList = new List<string>();

           
            DataList.Add(grossProfit);
            DataList.Add(totalRevenue);
            DataList.Add(costOfRevenue);
            DataList.Add(costofGoodsAndServicesSold);
            DataList.Add(operatingIncome);
            DataList.Add(sellingGeneralAndAdministrative);
            DataList.Add(researchAndDevelopment);
            DataList.Add(operatingExpenses);
            DataList.Add(investmentIncomeNet);
            DataList.Add(netInterestIncome);
            DataList.Add(interestIncome);
            DataList.Add(interestExpense);
            DataList.Add(nonInterestIncome);
            DataList.Add(otherNonOperatingIncome);
            DataList.Add(depreciation);
            DataList.Add(depreciationAndAmortization);
            DataList.Add(incomeBeforeTax);
            DataList.Add(incomeTaxExpense);
            DataList.Add(interestAndDebtExpense);
            DataList.Add(netIncomeFromContinuingOperations);
            DataList.Add(comprehensiveIncomeNetOfTax);
            DataList.Add(ebit);
            DataList.Add(ebitda);
            DataList.Add(netIncome);

            return DataList;
        }
    }

    public class CashFlowResponse : SymbolResponse// CashFlow
    {


        [JsonProperty("annualReports")]
        public List<CF_AnnualReport> CF_annualReports { get; set; }

        [JsonProperty("quarterlyReports")]
        public List<CF_QuarterlyReport> CF_quarterlyReports { get; set; }
        public CashFlowResponse(string apiKey, string symbol) : base(apiKey, symbol)
        {
            Address = $"https://www.alphavantage.co/query?function=CASH_FLOW&symbol={symbol}&apikey={apiKey}";
        }

        public override string FolderName { get { return "CashFlow"; } }
        public override void ensureIsSet()
        {
            try
            {
                if (CF_annualReports == null || CF_quarterlyReports == null)
                {
                    isSet = false;
                }
                else
                {
                    isSet = true;
                }
            }
            catch (Exception) { isSet = false; }

        }
        public class CF_AnnualReport
        {
            [JsonProperty("fiscalDateEnding")]
            public string fiscalDateEnding { get; set; }

            [JsonProperty("reportedCurrency")]
            public string reportedCurrency { get; set; }

            [JsonProperty("operatingCashflow")]
            public string operatingCashflow { get; set; }

            [JsonProperty("paymentsForOperatingActivities")]
            public string paymentsForOperatingActivities { get; set; }

            [JsonProperty("proceedsFromOperatingActivities")]
            public string proceedsFromOperatingActivities { get; set; }

            [JsonProperty("changeInOperatingLiabilities")]
            public string changeInOperatingLiabilities { get; set; }

            [JsonProperty("changeInOperatingAssets")]
            public string changeInOperatingAssets { get; set; }

            [JsonProperty("depreciationDepletionAndAmortization")]
            public string depreciationDepletionAndAmortization { get; set; }

            [JsonProperty("capitalExpenditures")]
            public string capitalExpenditures { get; set; }

            [JsonProperty("changeInReceivables")]
            public string changeInReceivables { get; set; }

            [JsonProperty("changeInInventory")]
            public string changeInInventory { get; set; }

            [JsonProperty("profitLoss")]
            public string profitLoss { get; set; }

            [JsonProperty("cashflowFromInvestment")]
            public string cashflowFromInvestment { get; set; }

            [JsonProperty("cashflowFromFinancing")]
            public string cashflowFromFinancing { get; set; }

            [JsonProperty("proceedsFromRepaymentsOfShortTermDebt")]
            public string proceedsFromRepaymentsOfShortTermDebt { get; set; }

            [JsonProperty("paymentsForRepurchaseOfCommonStock")]
            public string paymentsForRepurchaseOfCommonStock { get; set; }

            [JsonProperty("paymentsForRepurchaseOfEquity")]
            public string paymentsForRepurchaseOfEquity { get; set; }

            [JsonProperty("paymentsForRepurchaseOfPreferredStock")]
            public string paymentsForRepurchaseOfPreferredStock { get; set; }

            [JsonProperty("dividendPayout")]
            public string dividendPayout { get; set; }

            [JsonProperty("dividendPayoutCommonStock")]
            public string dividendPayoutCommonStock { get; set; }

            [JsonProperty("dividendPayoutPreferredStock")]
            public string dividendPayoutPreferredStock { get; set; }

            [JsonProperty("proceedsFromIssuanceOfCommonStock")]
            public string proceedsFromIssuanceOfCommonStock { get; set; }

            [JsonProperty("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
            public string proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

            [JsonProperty("proceedsFromIssuanceOfPreferredStock")]
            public string proceedsFromIssuanceOfPreferredStock { get; set; }

            [JsonProperty("proceedsFromRepurchaseOfEquity")]
            public string proceedsFromRepurchaseOfEquity { get; set; }

            [JsonProperty("proceedsFromSaleOfTreasuryStock")]
            public string proceedsFromSaleOfTreasuryStock { get; set; }

            [JsonProperty("changeInCashAndCashEquivalents")]
            public string changeInCashAndCashEquivalents { get; set; }

            [JsonProperty("changeInExchangeRate")]
            public string changeInExchangeRate { get; set; }

            [JsonProperty("netIncome")]
            public string netIncome { get; set; }
            public List<string> ReturnList() //returns a list of all the data that should be shown in the forms
            {
                List<string> returnList = new List<string>();
                returnList.Add(operatingCashflow);
                returnList.Add(paymentsForOperatingActivities);
                returnList.Add(proceedsFromOperatingActivities);
                returnList.Add(changeInOperatingLiabilities);
                returnList.Add(changeInOperatingAssets);
                returnList.Add(depreciationDepletionAndAmortization);
                returnList.Add(capitalExpenditures);
                returnList.Add(changeInReceivables);
                returnList.Add(changeInInventory);
                returnList.Add(profitLoss);
                returnList.Add(cashflowFromInvestment);
                returnList.Add(cashflowFromFinancing);
                returnList.Add(proceedsFromRepaymentsOfShortTermDebt);
                returnList.Add(paymentsForRepurchaseOfCommonStock);
                returnList.Add(paymentsForRepurchaseOfEquity);
                returnList.Add(paymentsForRepurchaseOfPreferredStock);
                returnList.Add(dividendPayout);
                returnList.Add(dividendPayoutCommonStock);
                returnList.Add(dividendPayoutPreferredStock);
                returnList.Add(proceedsFromIssuanceOfCommonStock);
                returnList.Add(proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet);
                returnList.Add(proceedsFromIssuanceOfPreferredStock);
                returnList.Add(proceedsFromRepurchaseOfEquity);
                returnList.Add(proceedsFromSaleOfTreasuryStock);
                returnList.Add(changeInCashAndCashEquivalents);
                returnList.Add(changeInExchangeRate);
                returnList.Add(netIncome);
                return returnList;
            }
        }

        public class CF_QuarterlyReport
        {
            [JsonProperty("fiscalDateEnding")]
            public string fiscalDateEnding { get; set; }

            [JsonProperty("reportedCurrency")]
            public string reportedCurrency { get; set; }

            [JsonProperty("operatingCashflow")]
            public string operatingCashflow { get; set; }

            [JsonProperty("paymentsForOperatingActivities")]
            public string paymentsForOperatingActivities { get; set; }

            [JsonProperty("proceedsFromOperatingActivities")]
            public string proceedsFromOperatingActivities { get; set; }

            [JsonProperty("changeInOperatingLiabilities")]
            public string changeInOperatingLiabilities { get; set; }

            [JsonProperty("changeInOperatingAssets")]
            public string changeInOperatingAssets { get; set; }

            [JsonProperty("depreciationDepletionAndAmortization")]
            public string depreciationDepletionAndAmortization { get; set; }

            [JsonProperty("capitalExpenditures")]
            public string capitalExpenditures { get; set; }

            [JsonProperty("changeInReceivables")]
            public string changeInReceivables { get; set; }

            [JsonProperty("changeInInventory")]
            public string changeInInventory { get; set; }

            [JsonProperty("profitLoss")]
            public string profitLoss { get; set; }

            [JsonProperty("cashflowFromInvestment")]
            public string cashflowFromInvestment { get; set; }

            [JsonProperty("cashflowFromFinancing")]
            public string cashflowFromFinancing { get; set; }

            [JsonProperty("proceedsFromRepaymentsOfShortTermDebt")]
            public string proceedsFromRepaymentsOfShortTermDebt { get; set; }

            [JsonProperty("paymentsForRepurchaseOfCommonStock")]
            public string paymentsForRepurchaseOfCommonStock { get; set; }

            [JsonProperty("paymentsForRepurchaseOfEquity")]
            public string paymentsForRepurchaseOfEquity { get; set; }

            [JsonProperty("paymentsForRepurchaseOfPreferredStock")]
            public string paymentsForRepurchaseOfPreferredStock { get; set; }

            [JsonProperty("dividendPayout")]
            public string dividendPayout { get; set; }

            [JsonProperty("dividendPayoutCommonStock")]
            public string dividendPayoutCommonStock { get; set; }

            [JsonProperty("dividendPayoutPreferredStock")]
            public string dividendPayoutPreferredStock { get; set; }

            [JsonProperty("proceedsFromIssuanceOfCommonStock")]
            public string proceedsFromIssuanceOfCommonStock { get; set; }

            [JsonProperty("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
            public string proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

            [JsonProperty("proceedsFromIssuanceOfPreferredStock")]
            public string proceedsFromIssuanceOfPreferredStock { get; set; }

            [JsonProperty("proceedsFromRepurchaseOfEquity")]
            public string proceedsFromRepurchaseOfEquity { get; set; }

            [JsonProperty("proceedsFromSaleOfTreasuryStock")]
            public string proceedsFromSaleOfTreasuryStock { get; set; }

            [JsonProperty("changeInCashAndCashEquivalents")]
            public string changeInCashAndCashEquivalents { get; set; }

            [JsonProperty("changeInExchangeRate")]
            public string changeInExchangeRate { get; set; }

            [JsonProperty("netIncome")]
            public string netIncome { get; set; }
            public List<string> ReturnList()
            {
                List<string> returnList = new List<string>(); //returns a list of all the data that should be shown in the forms
                returnList.Add(operatingCashflow);
                returnList.Add(paymentsForOperatingActivities);
                returnList.Add(proceedsFromOperatingActivities);
                returnList.Add(changeInOperatingLiabilities);
                returnList.Add(changeInOperatingAssets);
                returnList.Add(depreciationDepletionAndAmortization);
                returnList.Add(capitalExpenditures);
                returnList.Add(changeInReceivables);
                returnList.Add(changeInInventory);
                returnList.Add(profitLoss);
                returnList.Add(cashflowFromInvestment);
                returnList.Add(cashflowFromFinancing);
                returnList.Add(proceedsFromRepaymentsOfShortTermDebt);
                returnList.Add(paymentsForRepurchaseOfCommonStock);
                returnList.Add(paymentsForRepurchaseOfEquity);
                returnList.Add(paymentsForRepurchaseOfPreferredStock);
                returnList.Add(dividendPayout);
                returnList.Add(dividendPayoutCommonStock);
                returnList.Add(dividendPayoutPreferredStock);
                returnList.Add(proceedsFromIssuanceOfCommonStock);
                returnList.Add(proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet);
                returnList.Add(proceedsFromIssuanceOfPreferredStock);
                returnList.Add(proceedsFromRepurchaseOfEquity);
                returnList.Add(proceedsFromSaleOfTreasuryStock);
                returnList.Add(changeInCashAndCashEquivalents);
                returnList.Add(changeInExchangeRate);
                returnList.Add(netIncome);
                return returnList;
            }
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
            public TopLosersGainersResponse(string apikey) : base(apikey)
            {
                Address = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={apikey}";
            }
            public class MostActivelyTraded
            {
                [JsonProperty("ticker")]
                public string ticker { get; set; }

                [JsonProperty("price")]
                public string price { get; set; }

                [JsonProperty("change_amount")]
                public string change_amount { get; set; }

                [JsonProperty("change_percentage")]
                public string change_percentage { get; set; }

                [JsonProperty("volume")]
                public string volume { get; set; }
            }

            public class TopGainer
            {
                [JsonProperty("ticker")]
                public string ticker { get; set; }

                [JsonProperty("price")]
                public string price { get; set; }

                [JsonProperty("change_amount")]
                public string change_amount { get; set; }

                [JsonProperty("change_percentage")]
                public string change_percentage { get; set; }

                [JsonProperty("volume")]
                public string volume { get; set; }
            }

            public class TopLoser
            {
                [JsonProperty("ticker")]
                public string ticker { get; set; }

                [JsonProperty("price")]
                public string price { get; set; }

                [JsonProperty("change_amount")]
                public string change_amount { get; set; }

                [JsonProperty("change_percentage")]
                public string change_percentage { get; set; }

                [JsonProperty("volume")]
                public string volume { get; set; }
            }

            public override int deltaHours { get { return 2; } }
            public override string FolderName { get { return "TopLosersGainers"; } }
            public override string FileIdentifier { get { return "TopLosersGainers"; } }
            public override void ensureIsSet()
            {
                if (top_gainers == null || top_losers == null || most_actively_traded == null)
                {
                    isSet = false;
                }
                else
                {
                    isSet = true;
                }
            }
        }






        public class OverviewResponse : SymbolResponse //overview
        {
            public string AssetType { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string CIK { get; set; }
            public string Exchange { get; set; }
            public string Currency { get; set; }
            public string Country { get; set; }
            public string Sector { get; set; }
            public string Industry { get; set; }
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
            public OverviewResponse(string apiKey, string symbol) : base(apiKey, symbol)
            {
                Address = "https://www.alphavantage.co/query?function=OVERVIEW&symbol=" + symbol + "&apikey=" + apiKey;
            }
            public override string FolderName { get { return "Overview"; } }
            public override string FileIdentifier { get { return Symbol; } }
            public override void ensureIsSet()
            {

                if (ForwardPE == null & Beta == null & Sector == null)
                {
                    isSet= false;
                }
                else
                {
                    isSet = true;
                }
                
            }
        }
    }
}



