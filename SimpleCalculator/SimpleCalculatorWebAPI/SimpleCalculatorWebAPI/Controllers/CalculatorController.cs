﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculatorWebAPI.DTO;
using SimpleCalculatorWebAPI.Interfaces;

namespace SimpleCalculatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ResponseDto _responseDto { get; set; }
        private IMathOperations mathOperations { get; set; }

        public CalculatorController() { 
            _responseDto = new ResponseDto();
            mathOperations = new MathOperationsOne();
        }

        [HttpPost]
        [Route("AddTwoNumbers")]
        public ResponseDto AddTwoNumbers(NumberInputDto numberInputDto)
        {
            double result = mathOperations.Add(numberInputDto.firstnumber, numberInputDto.secondnumber);

            _responseDto.Result = result;
            _responseDto.Message = "Addition operation was successfull";

            return _responseDto;
        }

        [HttpPost]
        [Route("SubTwoNumbers")]
        public ResponseDto SubTwoNumbers(NumberInputDto numberInputDto)
        {
            double result = mathOperations.Sub(numberInputDto.firstnumber, numberInputDto.secondnumber);

            _responseDto.Result = result;
            _responseDto.Message = "Subtraction operation was successfull";

            return _responseDto;
        }

        [HttpPost]
        [Route("MultiplyTwoNumbers")]
        public ResponseDto MultiplyTwoNumbers(NumberInputDto numberInputDto)
        {
            double result = mathOperations.Mul(numberInputDto.firstnumber, numberInputDto.secondnumber);

            _responseDto.Result = result;
            _responseDto.Message = "Multiply operation was successfull";

            return _responseDto;
        }

        [HttpPost]
        [Route("DivideTwoNumbers")]
        public ResponseDto DivideTwoNumbers(NumberInputDto numberInputDto)
        {
            double result = mathOperations.Div(numberInputDto.firstnumber, numberInputDto.secondnumber);

            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                _responseDto.Result = 0.0;
                _responseDto.Message = "Division operation failed. Divide by zero attempted";
                _responseDto.Success = false;

                return _responseDto;
            }

            _responseDto.Result = result;
            _responseDto.Message = "Division operation was successfull";

            return _responseDto;
        }
    }
}
