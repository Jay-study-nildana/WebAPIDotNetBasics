using APICaller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SimpleCalculatorRazorMVCWebApp.DTO;
using System.Text;

namespace SimpleCalculatorRazorMVCWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/AddTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

            var EPHelper = new EndPointHelper();
            var result = await EPHelper.One(fullurl, requestbody);

            TempData["calculateresultstring"] = result;

            return RedirectToAction(nameof(CalculateResult));
        }

        [HttpPost]
        public async Task<IActionResult> CalculateSub(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/SubTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

            var EPHelper = new EndPointHelper();
            var result = await EPHelper.One(fullurl, requestbody);

            TempData["calculateresultstring"] = result;

            return RedirectToAction(nameof(CalculateResult));
        }

        [HttpPost]
        public async Task<IActionResult> CalculateMul(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/MultiplyTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

            var EPHelper = new EndPointHelper();
            var result = await EPHelper.One(fullurl, requestbody);

            TempData["calculateresultstring"] = result;

            return RedirectToAction(nameof(CalculateResult));
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDiv(NumberInputDto numberInputDto)
        {
            var fullurl = "https://localhost:7083/api/Calculator/DivideTwoNumbers";
            var requestbody = JsonConvert.SerializeObject(numberInputDto);

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
