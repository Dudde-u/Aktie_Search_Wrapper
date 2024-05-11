namespace Class_library
{
    public abstract class SymbolResponse : BaseResponse, ISaveable
    {

        public string Symbol { get; set; }
        public override string FileIdentifier { get { return Symbol; } }

        public override int deltaHours { get { return 2160; } }

        public SymbolResponse(string apiKey, string symbol) : base(apiKey)
        {
            Symbol = symbol.ToLower(); //might not be needed realistically

            

        }
        protected SymbolResponse() : base()
        {

            
        }
    }
}
