// This file is now under code-gen control, do not touch, will be regenerated frequenly
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Calculator.Api.Services;
using Calculator.Infrastructure;
using Calculator.Models;
using Calculator.Models.Enums;
using Calculator.Models.RequestResponse;
using Calculator.Models.ViewModels;
using Calculator.Service;
using Calculator.Service.Interfaces;

using Kendo.DynamicLinqCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private CalculatorDbContext _dbContext;
        private IMapper _mapper;
        private ICalculatorService _calculatorService;
        public CalculatorController(CalculatorDbContext dbContext, IMapper mapper, ICalculatorService calculatorService)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._calculatorService.AddIntegers(3, 5));
        }

        [HttpPost]
        [Route("DoAction")]
        public IActionResult DoAction(CalculatorDoActionBehaviorRequest request)
        {
            var result = "";
            var didError = false;
            var errorMsg = "";

            var value1 = request.Value1;
            var value2 = request.Value2;
            var behavior = request.Behavior;

            switch (behavior)
            {
                case CalculatorDoActionBehavior.Add:
                    {
                        try
                        {
                            result = _calculatorService.AddAsIntegers(value1, value2).ToString();
                        }
                        catch (FormatException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I was unable to convert {value1} and {value2} to proper numbers.  Review and try again?";
                        }
                        catch (ArithmeticException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                    }
                    break;
                case CalculatorDoActionBehavior.Subtract:
                    {
                        try
                        {
                            result = _calculatorService.SubAsIntegers(value1, value2).ToString();
                        }
                        catch (ArithmeticException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                        catch (InvalidCastException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I was unable to convert {value1} and {value2} to proper numbers.  Review and try again?";
                        }
                        
                    }
                    break;
                case CalculatorDoActionBehavior.Multiply:
                    {
                        try
                        {
                            result = _calculatorService.MultAsIntegers(value1, value2).ToString();
                        }
                        catch (InvalidCastException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I was unable to convert {value1} and {value2} to proper numbers.  Review and try again?";
                        }
                        catch (OverflowException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                        catch (ArithmeticException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                        
                    }

                    break;
                case CalculatorDoActionBehavior.Divide:
                    {
                        try
                        {
                            result = _calculatorService.DivAsIntegers(value1, value2).ToString();
                        }
                        catch (InvalidCastException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I was unable to convert {value1} and {value2} to proper numbers.  Review and try again?";
                        }
                        catch (OverflowException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                        catch (ArithmeticException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I encountered some impossible math with {value1} and {value2}.  Review and try again?";
                        }
                        
                    }
                    break;
                case CalculatorDoActionBehavior.AddStrings:
                    {
                        try
                        {
                            result = _calculatorService.AddAsStrings(value1, value2).ToString();
                        }
                        catch (FormatException e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I need two good values to perform this great action.  Review and try again?";
                        }
                        catch (Exception e)
                        {
                            didError = true;
                            errorMsg = $"{e.Message}\r\nApologies, but I have run into an unexpected error.  Review and try again?";
                        }
                        break;
                    }
                default:
                    {
                        didError = true;
                        errorMsg = "unclear what to do with this";
                        break;
                    }
            }
            if (didError) { return Ok(errorMsg); }
            return Ok(result);
        }
        private bool ValidateForInt(string value1, string value2)
        {
            var int1 = 0;
            var int2 = 0;

            return (int.TryParse(value1, out int1) && !int.TryParse(value2, out int2));
        }
    }
}
