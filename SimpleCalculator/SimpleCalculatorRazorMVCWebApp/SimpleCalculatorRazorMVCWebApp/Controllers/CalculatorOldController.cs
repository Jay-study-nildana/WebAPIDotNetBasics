using APICaller;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleCalculatorRazorMVCWebApp.DTO;
using System.Text;

namespace SimpleCalculatorRazorMVCWebApp.Controllers
{
    public class CalculatorOldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/AddTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

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
                string result = await response.Content.ReadAsStringAsync();

                TempData["calculateresultstring"] = result;

                return RedirectToAction(nameof(CalculateResult));
            }

            //return RedirectToAction(nameof(CalculateResult));
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateSub(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/SubTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

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
                string result = await response.Content.ReadAsStringAsync();

                TempData["calculateresultstring"] = result;

                return RedirectToAction(nameof(CalculateResult));
            }

            //return RedirectToAction(nameof(CalculateResult));
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateMul(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/MultiplyTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

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
                string result = await response.Content.ReadAsStringAsync();

                TempData["calculateresultstring"] = result;

                return RedirectToAction(nameof(CalculateResult));
            }

            //return RedirectToAction(nameof(CalculateResult));
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDiv(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/DivideTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

            //using (var http = new HttpClient())
            //using (var request = new HttpRequestMessage())
            //{
            //    //build the request
            //    request.Method = HttpMethod.Post;
            //    request.RequestUri = new Uri(fullurl);
            //    request.Content = new StringContent(requestbody, Encoding.UTF8, "application/json");//,Encoding.UTF8, "application/json"
            //    //request.Headers.Add("Accept", "application/json");

            //    //let's collect the response
            //    HttpResponseMessage response = await http.SendAsync(request).ConfigureAwait(false);
            //    string result = await response.Content.ReadAsStringAsync();

            //    TempData["calculateresultstring"] = result;

            //    return RedirectToAction(nameof(CalculateResult));
            //}

            //return RedirectToAction(nameof(CalculateResult));
            //return View();

            var EPHelper = new EndPointHelper();
            var result = await EPHelper.One(fullurl, requestbody);

            TempData["calculateresultstring"] = result;

            return RedirectToAction(nameof(CalculateResult));
        }

        public IActionResult CalculateResult()
        {
            var responseDTO = new ResponseDto();
            if (TempData["calculateresultstring"] is string s)
            {
                responseDTO = JsonConvert.DeserializeObject<ResponseDto>(s);
            }
            return View(responseDTO);
        }
    }
}
