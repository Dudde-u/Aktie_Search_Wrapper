using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_library
{
    public abstract class SymbolResponse : BaseResponse
    {

        protected string Symbol { get; set; }


        public SymbolResponse(string apiKey, string reqType, string symbol) : base(apiKey, reqType)
        {
            Symbol = symbol; //might not be needed realistically

            ResponseHelper.Symbol = symbol;

        }
        protected SymbolResponse() : base() 
        {
            
            Symbol = ResponseHelper.Symbol;
        }
    }
}
