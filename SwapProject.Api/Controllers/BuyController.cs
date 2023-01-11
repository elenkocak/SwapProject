using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.DTO.BuyCoinDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        IBuyCoinService _buyCoinService;

        public BuyController(IBuyCoinService buyCoinService)
        {
            _buyCoinService = buyCoinService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _buyCoinService.GetList();
            return Ok(result);
        }
        [HttpPost("Buyorder")]
        public IActionResult Create(BuyCoinCreateDto dto)
        {
            var result = _buyCoinService.Create(dto);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(BuyCoinUpdateDto dto)
        {
            var result = _buyCoinService.Update(dto);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _buyCoinService.Delete(id);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _buyCoinService.GetById(id);
            return Ok(result);
        }
    }
}
