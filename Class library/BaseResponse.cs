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
    public class BaseResponse
    {

        protected string apiKey { get; set; }
        public string Address { get; set; }
        protected string JsonString { get; set; }
        protected string reqType { get; set; }


        public BaseResponse() {}
        public BaseResponse(string apiKey, string reqType)
        {

            this.apiKey = apiKey;

            this.reqType = reqType;
          
        }
        public virtual async Task Initialize() 
        {
            await Task.Run(()=> SetAddress());
        }
        public void Completion(string apikey, string address, string jsonstring)  //During deserealization the whole object is replaced, therefore this:
        {
            apiKey = apiKey;
            Address = address;
            JsonString = jsonstring;
        }

     
        protected virtual void SetAddress() //For simplicitys' sake just a switch statement  
        {
            switch (reqType) // reqTypes to be added
            {
                case "LosersGainers":
                    Address = $"https://www.alphavantage.co/query?function=TOP_GAINERS_LOSERS&apikey={apiKey}";
                    break;
                default:
                    MessageBox.Show("TargetObject not valid");
                    throw new Exception();
            }
        }
    }
}
