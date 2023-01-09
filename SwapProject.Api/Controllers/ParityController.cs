using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.Concrete;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParityController : ControllerBase
    {
        IParityService _parityService;

        public ParityController(IParityService parityService)
        {
            _parityService = parityService;
        }
        [HttpPost("add")]
        public IActionResult Create(Parity parity)
        {
            var result = _parityService.Crete(parity);
            return Ok(result);
        }
    }
}
