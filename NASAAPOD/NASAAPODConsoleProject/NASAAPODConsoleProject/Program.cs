// See https://aka.ms/new-console-template for more information
using NASAAPODConsoleProject;
using Newtonsoft.Json;

var NASAAPODURL = "https://api.nasa.gov/planetary/apod?api_key=d7Qmzz1hVt9AdbNgKGKahCQcfP5rdm40uAK67XR1";

//first step is to get the HTTP Client

using (var client  = new HttpClient())
using (var request = new HttpRequestMessage())
{
    request.Method = HttpMethod.Get;
    request.RequestUri = new Uri(NASAAPODURL);
    //skipping the content part because I am not posting
    //headers, again, not required.
    HttpResponseMessage httpResponse = await client.SendAsync(request).ConfigureAwait(false);
    string result = await httpResponse.Content.ReadAsStringAsync();

    //public static NasaapodResponse FromJson(string json) => JsonConvert.DeserializeObject<NasaapodResponse>(json, NASAAPOD.Converter.Settings);
    //List<TranslationResponse> result_object = JsonConvert.DeserializeObject<List<TranslationResponse>>(result);
    var result_Object = JsonConvert.DeserializeObject<NasaapodResponse>(result);
    Console.WriteLine(result);

    //displaying the results
    Console.WriteLine("--------");
    Console.WriteLine("Title with Date");
    Console.WriteLine(result_Object?.Title + " "+result_Object?.Date.ToString());
    Console.WriteLine("--------");
    Console.WriteLine("Description");
    Console.WriteLine(result_Object?.Explanation);
    Console.WriteLine("--------");

}
