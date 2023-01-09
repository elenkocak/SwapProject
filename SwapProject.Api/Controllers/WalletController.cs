using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwapProject.Business.Abstract;
using SwapProject.Entity.DTO.WalletDto;

namespace SwapProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        [HttpGet("getlist")]
        public IActionResult Getlist()
        {
            var result = _walletService.GetList();
            return Ok(result);
        }
        //[HttpPost("createwallet")]
        //public IActionResult Create(WalletCreateDto dto)
        //{
        //    var result = _walletService.Create(dto);
        //    return Ok(result);
        //}
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _walletService.GetById(id);
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result=_walletService.Delete(id);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(WalletUpdateDto dto)
        {
            var result = _walletService.Update(dto);
            return Ok(result);
        }

    }
}
