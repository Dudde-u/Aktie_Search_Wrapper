using ClassLibrary;

namespace Class_library
{
    public abstract class SymbolResponse : BaseResponse
    {

        public string Symbol { get; set; }


        public SymbolResponse(string apiKey, string symbol) : base(apiKey)
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
