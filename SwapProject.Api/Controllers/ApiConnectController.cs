using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiConnectController : ControllerBase
    {
        IBinanceService _binanceService;

        public ApiConnectController(IBinanceService binanceService)
        {
            _binanceService = binanceService;
        }

        [HttpPost("connectapi")]

        public IActionResult GetParity(string parity)
        {
            var result =  _binanceService.RequestBinanceApi(parity);
            return Ok(result);  
        }
    }
}
