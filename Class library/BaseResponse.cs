using System.Threading.Tasks;

namespace Class_library
{
    public abstract class BaseResponse : ISettable, ISaveable
    {

        protected string apiKey { get; set; }
        public string Address { get; set; }
        public string JsonString { get; set; }
        public virtual string FileIdentifier { get; }
        public virtual string FolderName { get; }
        public virtual int deltaHours { get; }
        public bool IsSet { get; set; }
        public void EnsureIsSet()
        {
            if (!IsSet)
            {
                throw new System.Exception("Object not set");
            }
        }


        protected BaseResponse()
        {

            apiKey = ApiKeyHandler.Key; //maybe remove this line and always call the apikeyhandler
        }
        public BaseResponse(string apiKey)
        {

            this.apiKey = apiKey; //same thing here

        }
 

    }
}
