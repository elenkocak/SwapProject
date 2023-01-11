using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.Concrete;
using SwapProject.Entity.DTO.ParityDto;

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
        public IActionResult Create(ParityCreateDto parity)
        {
            var result = _parityService.Create(parity);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _parityService.GetList();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _parityService.GetById(id);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _parityService.Delete(id);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(ParityUpdateDto dto)
        {
            var result = _parityService.Update(dto);
            return Ok(result);
        }

    }
}
