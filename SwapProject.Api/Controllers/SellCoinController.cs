using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.DataAccess.Abstract;
using SwapProject.Entity.DTO.SellCoinDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellCoinController : ControllerBase
    {
         ISellCoinService _sellCoinService;

        public SellCoinController(ISellCoinService sellCoinService)
        {
            _sellCoinService = sellCoinService;
        }
        [HttpPost("sellorder")]
        public IActionResult SellOrder(SellCoinCreateDto dto)
        {
            var result = _sellCoinService.Create(dto);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public IActionResult Getlist()
        {
            var result = _sellCoinService.GetList();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_sellCoinService.GetById(id);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(SellCoinUpdateDto dto)
        {
            var result = _sellCoinService.Update(dto);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result=_sellCoinService.Delete(id);
            return Ok(result);
        }
    }
}
