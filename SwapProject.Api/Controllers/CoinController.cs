using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.DTO.CryptoCurrencyDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        ICoinService _cryptoCurrencyService;

        public CoinController(ICoinService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _cryptoCurrencyService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cryptoCurrencyService.GetById(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult Create(CoinsCreateDto dto)
        {
            var result = _cryptoCurrencyService.Create(dto);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Create(CoinsUpdateDto dto)
        {
            var result = _cryptoCurrencyService.Update(dto);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _cryptoCurrencyService.Delete(id);
            return Ok(result);
        }
    }
}
