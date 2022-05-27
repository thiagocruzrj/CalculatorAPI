using Calculator.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IOperationsService _service;

        public CalculatorController(IOperationsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/api/operation/sum")]
        public async Task<IActionResult> Add(string value1, string value2) => 
            Ok(await _service.Sum(value1, value2));

        [HttpGet]
        [Route("/api/operation/subtract")]
        public async Task<IActionResult> Subtract(string value1, string value2) => 
            Ok(await _service.Subtract(value1, value2));

        [HttpGet]
        [Route("/api/operation/multiply")]
        public async Task<IActionResult> Multiply(string value1, string value2) =>
            Ok(await _service.Multiply(value1, value2));

        [HttpGet]
        [Route("/api/opearion/divide")]
        public async Task<IActionResult> Divide(string value1, string value2) =>
            Ok(await _service.Divide(value1, value2));
    }
}