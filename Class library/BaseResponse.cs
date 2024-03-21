using ClassLibrary;
using System.Threading.Tasks;

namespace Class_library
{
    public abstract class BaseResponse
    {

        protected string apiKey { get; set; }
        public string Address { get; set; }
        protected string JsonString { get; set; }



        protected BaseResponse()
        {

            apiKey = ResponseHelper.apiKey;

            JsonString = ResponseHelper.JsonString;
            Address = ResponseHelper.Address;
        }
        public BaseResponse(string apiKey)
        {

            this.apiKey = apiKey;


            ResponseHelper.apiKey = apiKey;

        }
        public abstract Task Initialize();

        protected abstract void SetAddress();

    }
}
