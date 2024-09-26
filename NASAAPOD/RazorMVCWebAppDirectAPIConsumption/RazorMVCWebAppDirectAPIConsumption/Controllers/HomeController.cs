using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorMVCWebAppDirectAPIConsumption.Models;
using System.Diagnostics;

namespace RazorMVCWebAppDirectAPIConsumption.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> ShowNASAAPODAsync()
        {
            var NASAAPODURL = "https://api.nasa.gov/planetary/apod?api_key=d7Qmzz1hVt9AdbNgKGKahCQcfP5rdm40uAK67XR1";
            var response = new NasaapodResponse();

            ////first step is to get the HTTP Client

            using (var client = new HttpClient())
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
                response = result_Object;
            }

            return View(response);
        }

        public async Task<IActionResult> ShowNASAAPODAViaWebAPIsync()
        {
            var NASAAPODURL = "https://localhost:7244/WeatherForecast/GetNASAAPOD";
            var response = new NasaapodResponse();

            ////first step is to get the HTTP Client

            using (var client = new HttpClient())
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
                response = result_Object;
            }

            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
