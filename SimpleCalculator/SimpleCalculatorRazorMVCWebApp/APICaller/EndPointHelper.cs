using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICaller
{
    public class EndPointHelper
    {
        public async Task<string> One(string fullurl, string requestbody)
        {
            string result = "";

            using (var http = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                //build the request
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(fullurl);
                request.Content = new StringContent(requestbody, Encoding.UTF8, "application/json");//,Encoding.UTF8, "application/json"
                //request.Headers.Add("Accept", "application/json");

                //let's collect the response
                HttpResponseMessage response = await http.SendAsync(request).ConfigureAwait(false);
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}
