

namespace Class_library
{
    public abstract class BaseResponse : ISaveable, ISettable
    {
        public abstract void ensureIsSet();
        protected string apiKey { get; set; }
        public string Address { get; set; }
        public string JsonString { get; set; }
        public abstract string FileIdentifier { get; }
        public abstract string FolderName { get; }

        public abstract int deltaHours {  get; }
        public bool isSet { get; set; }




        protected BaseResponse()
        {

            apiKey = ApiKeyHandler.Key; 
        }
        public BaseResponse(string apiKey)
        {

            this.apiKey = apiKey; 

        }
        

    }
}
