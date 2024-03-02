using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_library
{
    public class SymbolResponse : BaseResponse
    {

        protected string Symbol { get; set; }


        public SymbolResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType)
        {
            Symbol = symbol;

        }
        public SymbolResponse() : base() { }
      
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
                    Address = "https://www.alphavantage.co/query?function=INCOME_STATEMENT&symbol=" + Symbol + "&apikey=" + apiKey;
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
}
