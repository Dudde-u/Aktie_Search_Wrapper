using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_library
{
    public abstract class BaseResponse
    {

        protected string apiKey { get; set; }
        public string Address { get; set; }
        protected string JsonString { get; set; }
        protected string reqType { get; set; } //not needed, but keeping it just in case for futures Archival features


        protected BaseResponse() {

            apiKey=ResponseHelper.apiKey;
            reqType=ResponseHelper.reqType;
            JsonString =ResponseHelper.JsonString;
            Address =ResponseHelper.Address;
        }
        public BaseResponse(string apiKey, string reqType)
        {

            this.apiKey = apiKey;
            this.reqType = reqType;

            ResponseHelper.apiKey = apiKey;
            ResponseHelper.reqType = reqType;
        }
        public abstract Task Initialize();
    
        protected abstract void SetAddress(); 

    }
}
