using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OmnivoreClassLibrary
{
    /// <summary>
    /// Responsible for handling the HTML responses and routing appropriately
    /// </summary>
    public static class ResponseHandler
    {
        public static async Task<dynamic> HandleResponseCode(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) // 200 OK
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(jsonString);
            }
            // else if, etc. (TODO)

            return new System.Dynamic.ExpandoObject(); // todo: take out later once I've handled everything.
        }

        //POSSIBLE ERROR CODES
        //200 OK: The request was successful. 
        //400 Bad Request: The request was malformed - check to see if you sent all the required parameters. 
        //401 Unauthorized: The API key provided was invalid, or you were unauthorized to handle the data. 
        //404 Not Found: The resource requested was not found on the server. 
        //500 Interal Server Error: Something went wrong on our end. Please contact us if this persists.
    }
}
