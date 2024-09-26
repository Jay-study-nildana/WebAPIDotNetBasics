using Microsoft.AspNetCore.Mvc;
using NASAAPODWebAPI.DTOs;
using Newtonsoft.Json;

namespace NASAAPODWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //add the new controller for NASA here. 
        //get all containers
        [HttpGet]
        [Route("GetNASAAPOD")]
        public async Task<NasaapodResponse> GetNASAAPOD()
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

                response.Title = "WEB API - " + response.Title;
            }

            return response;
        }
    }
}
