﻿using Calculator.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IOperationsService _service;

        public CalculatorController(IOperationsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/api/operation/sum")]
        public async Task<IActionResult> Add(string value1, string value2)
        {
            var response = await _service.Sum(value1, value2);
            return Ok(response);
        }

        [HttpGet]
        [Route("/api/operation/subtract")]
        public async Task<IActionResult> Subtract(string value1, string value2)
        {
            var response = await _service.Subtract(value1, value2);
            return Ok(response);
        }

        [HttpGet]
        [Route("/api/operation/multiply")]
        public async Task<IActionResult> Multiply(string value1, string value2)
        {
            var response = await _service.Multiply(value1, value2);
            return Ok(response);
        }

        [HttpGet]
        [Route("/api/opearion/divide")]
        public async Task<IActionResult> Divide(string value1, string value2)
        {
            var response = await _service.Divide(value1, value2);
            return Ok(response);
        }
    }
}