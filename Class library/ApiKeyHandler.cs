using ClassLibrary;
using System.Threading.Tasks;

namespace Class_library
{
    public static class ApiKeyHandler
    {
        public static string Key { get; set; }
        public static bool KeyIsValidated { get; set; }

        public async static Task<bool> ValidateAsync(string prekey) // validates key with incomeStatement request.
        {
            //  Note that any non-key related issues will still result in no validation

            GlobalQuoteResponse GQ = new GlobalQuoteResponse(prekey, "IBM");
            await GQ.Initialize(); //Fix Async behaviour here

            GQ = await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(GQ, GQ.Address);

            GlobalQuoteResponse demoGQ = new GlobalQuoteResponse("demo", "IBM");
            await demoGQ.Initialize(); //Fix Async behaviour here

            demoGQ = await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(demoGQ, demoGQ.Address);




            string temp = null;
            string temp2 = null;//does not really matter what the strings are assigned at first.
            try
            {
                temp = GQ.GlobalQuote._06volume;
                temp2 = demoGQ.GlobalQuote._06volume;
            }
            catch
            {
                KeyIsValidated = false;
                return false;
            }
            if (temp == temp2 && temp != null)
            {
                KeyIsValidated = true;
                Key = prekey;
                return true;
            }
            else
            {
                KeyIsValidated = false;
                Key = prekey;
                return false;
            }

        }
    }
}
